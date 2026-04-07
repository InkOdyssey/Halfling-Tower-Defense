using Godot;
using System;

public partial class TeaCup : TestEnemy
{
	override public void _Ready()
	{
		GD.Print("tea drinker");
		health = 2;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
