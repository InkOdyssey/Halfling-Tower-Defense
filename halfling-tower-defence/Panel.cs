using Godot;
using System;

public partial class Shop : Panel
{
	[Export] public PackedScene PirateTowerScene;
	[Export] public PackedScene BlackbeardTowerScene;

	private int playerMoney = 200;

	public override void _Ready()
	{
		GetNode<Button>("VBoxContainer/Pirate_Button1").Pressed += OnPirateTowerPressed;
		GetNode<Button>("VBoxContainer/Pirate_Button2").Pressed += OnBlackbeardTowerPressed;
	}

	private void OnPirateTowerPressed()
	{
		TryBuyTower(PirateTowerScene, 45);
	}

	private void OnBlackbeardTowerPressed()
	{
		TryBuyTower(BlackbeardTowerScene, 75);
	}

	private void TryBuyTower(PackedScene towerScene, int cost)
	{
		if (playerMoney < cost)
		{
			GD.Print("Not enough money!");
			return;
		}

		playerMoney -= cost;

		var tower = towerScene.Instantiate();
		GetTree().CurrentScene.AddChild(tower);
	}
	public override void _Process(double delta)
	{
		GetNode<Button>("VBoxContainer/PirateTowerButton").Disabled = playerMoney < 50;
	}
}
