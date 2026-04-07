using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	[Export] public int StartingHearts = 200;
	[Export] public int StartingCoins = 100;

	private Label _numLife;
	private Label _coinLabel;

	private int _currentHearts;
	private int _currentCoins;

	public event Action CoinsChanged;

	public override void _EnterTree()
	{
		if (Instance != null && Instance != this)
		{
			GD.PrintErr("Duplicate GameManager detected!");
			QueueFree();
			return;
		}

		Instance = this;
		GD.Print("GameManager set. ID: " + GetInstanceId());
	}

	public override void _Ready()
	{
		_currentHearts = StartingHearts;
		_currentCoins = StartingCoins;

		_numLife = GetNodeOrNull<Label>("MarginContainer/Life_num/Num_life");
		_coinLabel = GetNodeOrNull<Label>("MarginContainer/Score/Num");

		UpdateUI();
		GD.Print("GameManager ready with coins: " + _currentCoins);
	}

	public void AddCoins(int amount)
	{
		_currentCoins += amount;
		GD.Print("Coins added. Now: " + _currentCoins);
		UpdateUI();
		CoinsChanged?.Invoke();
	}

	public bool SpendCoins(int amount)
	{
		GD.Print("SpendCoins called. Before: " + _currentCoins + " Cost: " + amount);

		if (_currentCoins < amount)
		{
			GD.Print("Not enough coins!");
			return false;
		}

		_currentCoins -= amount;

		GD.Print("Coins now: " + _currentCoins);

		UpdateUI();
		CoinsChanged?.Invoke();
		return true;
	}

	public int GetCurrentCoins()
	{
		return _currentCoins;
	}

	public void LoseHearts(int amount)
	{
		_currentHearts = Mathf.Max(_currentHearts - amount, 0);
		UpdateUI();

		if (_currentHearts <= 0)
		{
			GD.Print("GAME OVER");
			GetTree().Paused = true;
		}
	}

	private void UpdateUI()
	{
		if (_numLife != null)
			_numLife.Text = _currentHearts.ToString();

		if (_coinLabel != null)
			_coinLabel.Text = _currentCoins.ToString();
	}
}
