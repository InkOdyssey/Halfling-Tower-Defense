using Godot;
using System;

public partial class Shop : Panel
{
	private const int PirateCost = 20;
	private const int BlackbeardCost = 40;
	private const int CannonCost = 50;
	private const int BombCost = 60;
	private const int PirateShipCost = 90;
	
	private Map map;

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

		pirateButton.Pressed += () => TryBuy(GetPirateTower(), PirateCost, 1);
		blackbeardButton.Pressed += () => TryBuy(GetBlackbeardTower(), BlackbeardCost, 2);
		cannonButton.Pressed += () => TryBuy(GetCannonTower(), CannonCost, 3);
		bombButton.Pressed += () => TryBuy(GetBombTower(), BombCost, 4);
		pirateShipButton.Pressed += () => TryBuy(GetPirateShipTower(), PirateShipCost, 5);

		toggleButton.Pressed += ToggleShop;

		openPosition = Position;
		closedPosition = openPosition + new Vector2(-200, 0);
		
		
		map = GetNode<Map>("/root/map");
	}

	private PackedScene GetPirateTower() => GD.Load<PackedScene>("res://Scenes/Towers/scalleywag.tscn");
	private PackedScene GetBlackbeardTower() => GD.Load<PackedScene>("res://Scenes/Towers/Blackbeard.tscn");
	private PackedScene GetCannonTower() => GD.Load<PackedScene>("res://Scenes/Towers/cannon.tscn");
	private PackedScene GetBombTower() => GD.Load<PackedScene>("res://Scenes/Towers/bomber.tscn");
	private PackedScene GetPirateShipTower() => GD.Load<PackedScene>("res://Scenes/Towers/pirate_ship.tscn");




	private void TryBuy(PackedScene tower, int cost, int towernum)
	{
		GD.Print("trying buying");
		
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
				map.StartPlacingScalleywag();
				GD.Print("placing test tower");
				break;
			case 2:
				map.StartPlacingBlackbeard();
				break;
			case 3:
				map.StartPlacingCannon();
				break;
			case 4: 
				map.StartPlacingBomber();
				break;
			case 5:
				map.StartPlacingPirate_Ship();
				break;
		}
	}

	private void ToggleShop()
	{
		isOpen = !isOpen;
		var tween = CreateTween();
		tween.TweenProperty(this, "position", isOpen ? openPosition : closedPosition, 0.25f);
	}

}
