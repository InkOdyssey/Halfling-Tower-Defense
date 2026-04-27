using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class LeaderboardEntry
{
	public string Name { get; set; } = "";
	public int Waves { get; set; }
}

public static class GameData
{
	public static List<LeaderboardEntry> LeaderboardEntries { get; set; } = new();
	private const string SavePath = "user://leaderboard.json";

	public static event Action LeaderboardChanged;

	public static void AddScore(string name, int waves)
	{
		if (string.IsNullOrWhiteSpace(name))
			name = "Anonymous";

		LeaderboardEntries.Add(new LeaderboardEntry
		{
			Name = name,
			Waves = waves
		});

		LeaderboardEntries = LeaderboardEntries
			.OrderByDescending(e => e.Waves)
			.Take(10)
			.ToList();

		SaveLeaderboard();
		LeaderboardChanged?.Invoke();
	}

	public static void SaveLeaderboard()
	{
		var json = JsonSerializer.Serialize(LeaderboardEntries);
		using var file = Godot.FileAccess.Open(SavePath, Godot.FileAccess.ModeFlags.Write);
		file.StoreString(json);
	}

	public static void LoadLeaderboard()
	{
		if (!Godot.FileAccess.FileExists(SavePath))
			return;

		using var file = Godot.FileAccess.Open(SavePath, Godot.FileAccess.ModeFlags.Read);
		var json = file.GetAsText();
		LeaderboardEntries = JsonSerializer.Deserialize<List<LeaderboardEntry>>(json) ?? new();
	}
}
