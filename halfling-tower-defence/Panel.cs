using Godot;
using System;

public partial class Shop : Panel
{
	[Export] public PackedScene PirateTowerScene;
	[Export] public PackedScene BlackbeardTowerScene;
	[Export] public PackedScene BombTowerScene;
	[Export] public PackedScene PirateShipTowerScene;

	private const int PirateCost = 45;
	private const int BlackbeardCost = 75;
	private const int BombCost = 60;
	private const int PirateShipCost = 100;

	private int playerMoney = 200;

	private Button pirateButton;
	private Button blackbeardButton;
	private Button bombButton;
	private Button pirateShipButton;
	private Button toggleButton;
	private Label moneyLabel;

	private PackedScene selectedTower = null;
	private Node2D previewTower = null;

	private const int GridSize = 64;

	private bool isOpen = true;
	private Vector2 openPosition;
	private Vector2 closedPosition;

	public override void _Ready()
	{
		// Cache UI nodes
		pirateButton = GetNode<Button>("VBoxContainer/Pirate_Button1");
		blackbeardButton = GetNode<Button>("VBoxContainer/Pirate_Button2");
		bombButton = GetNode<Button>("VBoxContainer/Bomb_Button");
		pirateShipButton = GetNode<Button>("VBoxContainer/PirateShip_Button");
		moneyLabel = GetNode<Label>("VBoxContainer/MoneyLabel");
		toggleButton = GetNode<Button>("VBoxContainer/ToggleButton");

		// Connect signals
		pirateButton.Pressed += OnPirateTowerPressed;
		blackbeardButton.Pressed += OnBlackbeardTowerPressed;
		bombButton.Pressed += OnBombTowerPressed;
		pirateShipButton.Pressed += OnPirateShipTowerPressed;
		toggleButton.Pressed += ToggleShop;

		openPosition = Position;
		closedPosition = openPosition + new Vector2(-200, 0);

		UpdateUI();
	}

	private void ToggleShop()
	{
		isOpen = !isOpen;

		toggleButton.Text = isOpen ? "Close Shop" : "Open Shop";

		Vector2 target = isOpen ? openPosition : closedPosition;

		var tween = CreateTween();
		tween.TweenProperty(this, "position", target, 0.3)
			.SetTrans(Tween.TransitionType.Sine)
			.SetEase(Tween.EaseType.InOut);
	}

	private void OnPirateTowerPressed()
	{
		TryBuyTower(PirateTowerScene, PirateCost);
	}

	private void OnBlackbeardTowerPressed()
	{
		TryBuyTower(BlackbeardTowerScene, BlackbeardCost);
	}

	private void OnBombTowerPressed()
	{
		TryBuyTower(BombTowerScene, BombCost);
	}

	private void OnPirateShipTowerPressed()
	{
		TryBuyTower(PirateShipTowerScene, PirateShipCost);
	}

	private void TryBuyTower(PackedScene towerScene, int cost)
	{
		if (playerMoney < cost)
		{
			GD.Print("Not enough money!");
			return;
		}

		playerMoney -= cost;
		selectedTower = towerScene;

		CreatePreview();

		UpdateUI();
	}

	private void CreatePreview()
	{
		if (previewTower != null)
			previewTower.QueueFree();

		previewTower = selectedTower.Instantiate<Node2D>();
		previewTower.ZIndex = 10;

		GetTree().CurrentScene.AddChild(previewTower);
	}

	public override void _Process(double delta)
	{
		if (previewTower != null)
		{
			Vector2 mousePos = GetGlobalMousePosition();
			Vector2 snapped = SnapToGrid(mousePos);

			previewTower.Position = snapped;

			bool canPlace = CanPlace(snapped);
			SetPreviewColor(previewTower, canPlace);
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed)
		{
			// 🚫 Prevent placing when clicking UI
			if (GetViewport().GuiGetHoveredControl() != null)
				return;

			// LEFT CLICK = PLACE
			if (mouseEvent.ButtonIndex == MouseButton.Left)
			{
				if (selectedTower != null && previewTower != null)
				{
					if (CanPlace(previewTower.Position))
					{
						var tower = selectedTower.Instantiate<Node2D>();
						tower.Position = previewTower.Position;
						tower.ZIndex = 10;

						GetTree().CurrentScene.AddChild(tower);

						ClearPlacement();
					}
					else
					{
						GD.Print("Invalid placement!");
					}
				}
			}

			// RIGHT CLICK = CANCEL
			if (mouseEvent.ButtonIndex == MouseButton.Right)
			{
				ClearPlacement();
			}
		}
	}

	private void ClearPlacement()
	{
		selectedTower = null;

		if (previewTower != null)
		{
			previewTower.QueueFree();
			previewTower = null;
		}
	}

	// ✅ CENTERED GRID SNAP
	private Vector2 SnapToGrid(Vector2 position)
	{
		return new Vector2(
			Mathf.Floor(position.X / GridSize) * GridSize + GridSize / 2,
			Mathf.Floor(position.Y / GridSize) * GridSize + GridSize / 2
		);
	}

	private bool CanPlace(Vector2 position)
	{
		return true; // expand later
	}

	// ✅ GREEN / RED PREVIEW
	private void SetPreviewColor(Node node, bool canPlace)
	{
		Color color = canPlace
			? new Color(0.7f, 1f, 0.7f, 0.5f)  // green
			: new Color(1f, 0.4f, 0.4f, 0.5f); // red

		if (node is CanvasItem canvasItem)
		{
			canvasItem.Modulate = color;
		}

		foreach (Node child in node.GetChildren())
		{
			SetPreviewColor(child, canPlace);
		}
	}

	private void UpdateUI()
	{
		moneyLabel.Text = $"Money: {playerMoney}";

		pirateButton.Disabled = playerMoney < PirateCost;
		blackbeardButton.Disabled = playerMoney < BlackbeardCost;
		bombButton.Disabled = playerMoney < BombCost;
		pirateShipButton.Disabled = playerMoney < PirateShipCost;
	}
}
