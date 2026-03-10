using Godot;
using System;

public partial class TestEnemy : CharacterBody2D
{
	private PathFollow2D pathprogress;

	public override void _Ready()
	{
		pathprogress = GetParentOrNull<PathFollow2D>();

		if (pathprogress == null)
		{
			GD.PrintErr("TestEnemy: PathFollow2D parent not found!");
		}
	}

	public override void _Process(double delta)
	{
		if (pathprogress == null)
			return;

		pathprogress.ProgressRatio += .001;

		if (pathprogress.ProgressRatio >= 1.0f)
		{
			GD.Print("Freed");

			if (GameManager.Instance != null)
				GameManager.Instance.LoseHearts(10);
			else
				GD.PrintErr("GameManager.Instance is NULL!");

			QueueFree();
		}
	}

	private void OnKill()
	{
		GD.Print("Enemy killed");
		QueueFree();
	}
}
