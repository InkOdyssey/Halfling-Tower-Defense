using Godot;
using System;

public partial class TestEnemy : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var kill = GetNode<Enemyprogression>("/root/map/Path2D/PathFollow2D");
		
		kill.Kill += OnKill;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void OnKill()
	{
		GD.Print("killed");
		QueueFree();
		
	}
}
