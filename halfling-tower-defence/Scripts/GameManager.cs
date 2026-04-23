using Godot;
using System;
using System.Collections.Generic;
using System.Text.Json;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	[Export] public int StartingHearts = 200;
	[Export] public int StartingCoins = 100;

	private int wave = 0;
	public int GetCurrentWaves() => wave;
	public int CurrentWaves
	{
		get => wave;
		set
		{
			wave = value;
		}
	}

	private Label _numLife;
	private Label _coinLabel;

	private int _currentHearts;
	private int _currentCoins;

	public event Action CoinsChanged;

	private const string LeaderboardPath = "user://leaderboard.json";

	public override void _EnterTree()
	{
		Instance = this;
		GD.Print("GameManager set. ID: " + GetInstanceId());
	}

	public override void _Ready()
	{
		_currentHearts = StartingHearts;
		_currentCoins = StartingCoins;

		_numLife = GetNodeOrNull<Label>("%Num_life");
		_coinLabel = GetNodeOrNull<Label>("%Num_coins");

		UpdateUI();
	}

	public void AddCoins(int amount)
	{
		_currentCoins += amount;
		UpdateUI();
		CoinsChanged?.Invoke();
	}

	public bool SpendCoins(int amount)
	{
		if (_currentCoins < amount)
		{
			return false;
		}
		_currentCoins -= amount;
		UpdateUI();
		CoinsChanged?.Invoke();
		return true;
	}

	public int GetCurrentCoins() => _currentCoins;

	public void LoseHearts(int amount)
	{
		_currentHearts = Mathf.Max(_currentHearts - amount, 0);
		UpdateUI();

		if (_currentHearts <= 0)
			GetTree().ChangeSceneToFile("res://Scenes/GameOver.tscn");
	}

	public void SubmitScore(string playerName, int waves)
	{
		GameData.AddScore(playerName, waves);
		GD.Print($"Score submitted: {playerName} - {waves} waves");
	}

	private void UpdateUI()
	{
		if (_numLife != null)
			_numLife.Text = _currentHearts.ToString();

		if (_coinLabel != null)
			_coinLabel.Text = _currentCoins.ToString();
	}
}
