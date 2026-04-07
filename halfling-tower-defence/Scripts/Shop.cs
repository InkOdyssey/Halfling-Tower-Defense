using Godot;
using System;

public partial class Shop : Panel
{
	private const int PirateCost = 20;
	private const int BlackbeardCost = 40;
	private const int CannonCost = 50;
	private const int BombCost = 60;
	private const int PirateShipCost = 90;
	private int towernum;

	private Button pirateButton;
	private Button blackbeardButton;
	private Button cannonButton;
	private Button bombButton;
	private Button pirateShipButton;
	private Button toggleButton;

	private PackedScene selectedTower;
	private Node2D previewTower;
	private const int GridSize = 64;
	private bool isOpen = true;
	private Vector2 openPosition;
	private Vector2 closedPosition;

	public override void _Ready()
	{
		pirateButton = GetNode<Button>("VBoxContainer/Pirate_Button1");
		blackbeardButton = GetNode<Button>("VBoxContainer/Pirate_Button2");
		cannonButton = GetNode<Button>("VBoxContainer/Cannon_Button");
		bombButton = GetNode<Button>("VBoxContainer/Bomb_Button");
		pirateShipButton = GetNode<Button>("VBoxContainer/PirateShip_Button");
		toggleButton = GetNode<Button>("VBoxContainer/ToggleButton");

		pirateButton.Pressed += () => TryBuy(GetPirateTower(), PirateCost);
		blackbeardButton.Pressed += () => TryBuy(GetBlackbeardTower(), BlackbeardCost);
		cannonButton.Pressed += () => TryBuy(GetCannonTower(), CannonCost);
		bombButton.Pressed += () => TryBuy(GetBombTower(), BombCost);
		pirateShipButton.Pressed += () => TryBuy(GetPirateShipTower(), PirateShipCost);

		toggleButton.Pressed += ToggleShop;

		openPosition = Position;
		closedPosition = openPosition + new Vector2(-200, 0);
	}

	private PackedScene GetPirateTower() => GD.Load<PackedScene>("res://Scenes/Towers/scalleywag.tscn");
	private PackedScene GetBlackbeardTower() => GD.Load<PackedScene>("res://Scenes/Towers/Blackbeard.tscn");
	private PackedScene GetCannonTower() => GD.Load<PackedScene>("res://Scenes/Towers/cannon.tscn");
	private PackedScene GetBombTower() => GD.Load<PackedScene>("res://Scenes/Towers/bomber.tscn");
	private PackedScene GetPirateShipTower() => GD.Load<PackedScene>("res://Scenes/Towers/pirate_ship.tscn");

	private void TryBuy(PackedScene tower, int cost)
	{
		if (GameManager.Instance == null)
		{
			GD.PrintErr("GameManager is NULL");
			return;
		}

		if (tower == null)
		{
			GD.PrintErr("Tower scene missing!");
			return;
		}

		if (!GameManager.Instance.SpendCoins(cost))
			return;

		selectedTower = tower;
		switch (towernum)
		{
			case 1:
				
				break;
			case 2:
				
				break;
			case 3:
				
				break;
			case 4: 
				
				break;
			case 5:
				
				break;
		}
	}

	private void CreatePreview()
	{
		if (selectedTower == null) return;

		if (previewTower != null)
			previewTower.QueueFree();

		previewTower = selectedTower.Instantiate<Node2D>();
		previewTower.ZIndex = 10;
		GetTree().CurrentScene.AddChild(previewTower);
	}

	private void Clear()
	{
		selectedTower = null;
		if (previewTower != null)
		{
			previewTower.QueueFree();
			previewTower = null;
		}
	}

	private void ToggleShop()
	{
		isOpen = !isOpen;
		var tween = CreateTween();
		tween.TweenProperty(this, "position", isOpen ? openPosition : closedPosition, 0.25f);
	}
	private void _on_pirate_button_1_pressed()
	{
		towernum = 1;
	}
	
	
	private void _on_pirate_button_2_pressed()
	{
		towernum = 2;
	}

	private void _on_cannon_button_pressed()
	{
		towernum = 3;
	}
	
	private void _on_bomb_button_pressed()
	{
		towernum = 4;
	}
	private void _on_pirate_ship_button_pressed()
	{
		towernum = 5;
	}
}
