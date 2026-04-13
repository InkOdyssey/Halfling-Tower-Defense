using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	[Export] public int StartingHearts = 200;
	[Export] public int StartingCoins = 100;
	[Export] public PauseMenu PauseMenu;
	
	private Label _numLife;
	private Label _coinLabel;

	private int _currentHearts;
	private int _currentCoins;

	public override void _EnterTree()
	{
		if (Instance != null && Instance != this)
		{
			QueueFree();
			return;
		}

		Instance = this;
	}
	
		public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("Pause"))
		{
			if (PauseMenu == null)
			{
				GD.PrintErr("PauseMenu is null.");
				return;
			}
			{
			PauseMenu.ShowMenu();
			GetTree().Paused = true;
			GetViewport().SetInputAsHandled();
			}
		}
	}
	
	public override void _Ready()
	{
		_currentHearts = StartingHearts;
		_currentCoins = StartingCoins;

		_numLife = GetNodeOrNull<Label>("MarginContainer/Life_num/Num_life");
		_coinLabel = GetNodeOrNull<Label>("MarginContainer/Score/Num");

		if (_numLife == null)
			GD.PrintErr("Num_life label not found!");

		if (_coinLabel == null)
			GD.PrintErr("Coin label not found!");

		PauseMenu = GetNode<PauseMenu>("CanvasLayer/PauseMenu");
		UpdateUI();
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

	public void AddCoins(int amount)
	{
		_currentCoins += amount;
		UpdateUI();
	}

	public bool SpendCoins(int amount)
	{
		if (_currentCoins < amount)
			return false;

		_currentCoins -= amount;
		UpdateUI();
		return true;
	}

	private void UpdateUI()
	{
		if (_numLife != null)
			_numLife.Text = _currentHearts.ToString();

		if (_coinLabel != null)
			_coinLabel.Text = _currentCoins.ToString();
	}
}
