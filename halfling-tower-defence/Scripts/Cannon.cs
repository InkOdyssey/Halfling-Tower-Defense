using Godot;
using System;

public partial class Cannon : Node2D
{
	
	public override void _Ready()
	{
		GD.Print("test");
	}

	public void in_range(Node2D body)
	{
		GD.Print("in zone");
	}
	
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
