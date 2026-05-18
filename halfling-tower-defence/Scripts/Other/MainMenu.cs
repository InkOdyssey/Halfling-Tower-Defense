using Godot;
using System;

public partial class MainMenu : Control
{
	[Export] public VBoxContainer EntriesContainer;
	[Export] public string LevelSelectScenePath = "res://Level_Select_Menu.tscn";

	public override void _Ready()
	{
		GetNode<Button>("Start_Button").Pressed += OnStartPressed;
		GetNode<Button>("End_Button").Pressed += _Quit;

		EntriesContainer ??= GetNode<VBoxContainer>("%Entries_Container");

		if (EntriesContainer == null)
		{
			GD.PrintErr("EntriesContainer could not be found.");
			return;
		}

		GameData.LoadLeaderboard();
		GameData.LeaderboardChanged += RefreshLeaderboardUI;
		CallDeferred(nameof(RefreshLeaderboardUI));
	}

	public override void _ExitTree()
	{
		GameData.LeaderboardChanged -= RefreshLeaderboardUI;
	}

	private void OnStartPressed()
	{
		GetTree().ChangeSceneToFile(LevelSelectScenePath);
	}

	private void _Quit()
	{
		GetTree().Quit();
	}

	private void RefreshLeaderboardUI()
	{
		GD.Print($"Entries count: {GameData.LeaderboardEntries?.Count ?? 0}");

		foreach (Node child in EntriesContainer.GetChildren())
			child.QueueFree();

		if (GameData.LeaderboardEntries == null || GameData.LeaderboardEntries.Count == 0)
		{
			AddLeaderboardRow("", "No scores yet!", "Beat the game to submit.");
			return;
		}

		for (int i = 0; i < GameData.LeaderboardEntries.Count; i++)
		{
			var entry = GameData.LeaderboardEntries[i];
			AddLeaderboardRow($"#{i + 1}", entry.Name, $"{entry.Waves} waves");
		}
	}

	private void AddLeaderboardRow(string rank, string name, string waves)
	{
		var row = new HBoxContainer
		{
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill
		};

		var rankLabel = new Label
		{
			Text = rank,
			CustomMinimumSize = new Vector2(60, 0),
			SizeFlagsHorizontal = Control.SizeFlags.ShrinkBegin
		};

		var nameLabel = new Label
		{
			Text = name,
			SizeFlagsHorizontal = Control.SizeFlags.ExpandFill
		};

		var wavesLabel = new Label
		{
			Text = waves,
			CustomMinimumSize = new Vector2(100, 0),
			SizeFlagsHorizontal = Control.SizeFlags.ShrinkEnd
		};

		row.AddChild(rankLabel);
		row.AddChild(nameLabel);
		row.AddChild(wavesLabel);
		EntriesContainer.AddChild(row);
	}
}
