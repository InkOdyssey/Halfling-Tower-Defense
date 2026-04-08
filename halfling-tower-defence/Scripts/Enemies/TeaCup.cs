using Godot;
using System;

public partial class TeaCup : TestEnemy
{
	override public void _Ready()
	{
		health = 20;
		pathprogress.ProgressRatio += .002f;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
