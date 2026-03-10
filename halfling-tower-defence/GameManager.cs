using Godot;
using System;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	[Export] public int StartingHearts = 200;
	[Export] private Label _numLife; 

	private int _currentHearts;

	public override void _Ready()
{
	if (Instance != null && Instance != this)
	{
		QueueFree();
		return;
	}

	Instance = this;

	_currentHearts = StartingHearts;

	// Use your actual node path
	_numLife = GetNodeOrNull<Label>("MarginContainer/Life_num/Num_life");
	if (_numLife == null)
	{
		GD.PrintErr("Num_life label not found at $MarginContainer/Life_num/Num_life!");
		return;
	}

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

	private void UpdateUI()
	{
		_numLife.Text = _currentHearts.ToString();
	}
}
