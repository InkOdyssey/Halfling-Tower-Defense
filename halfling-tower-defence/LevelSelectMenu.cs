using Godot;
using System;

public partial class LevelSelectMenu : Control
{
	[Export] public string MainMenuScenePath = "res://Scenes/Other/Start_Menu.tscn";
	[Export] public string Level1ScenePath = "res://Scenes/Map/map_lvl1.tscn";
	[Export] public string Level2ScenePath = "res://Scenes/Map/map.tscn";

	public override void _Ready()
	{
		GetNode<Button>("Level1_Button").Pressed += () => LoadLevel(Level1ScenePath);
		GetNode<Button>("Level2_Button").Pressed += () => LoadLevel(Level2ScenePath);
		GetNode<Button>("Return_Button").Pressed += OnMainMenuPressed;
	}

	private void LoadLevel(string scenePath)
	{
		GetTree().ChangeSceneToFile(scenePath);
	}

	private void OnMainMenuPressed()
	{
		GD.Print($"Returning to main menu: {MainMenuScenePath}");
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile(MainMenuScenePath);
	}
}
