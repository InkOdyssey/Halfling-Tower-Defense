using Godot;
using System;

public partial class Cannon : Tower
{
	
	public override void _Ready()
	{
		damageAmount = 50;
		base._Ready();
	}
	
	
	
	
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
