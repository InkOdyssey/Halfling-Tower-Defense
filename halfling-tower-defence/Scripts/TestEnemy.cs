using Godot;
using System;

public partial class TestEnemy : Node2D
{
	
	private int health = 3;
	private bool Damage = false;
	

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var kill = GetNode<Enemyprogression>("/root/map/Path2D/PathFollow2D");
		
		kill.Kill += OnKill;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (health < 1)
		{
			QueueFree();
		}
	}
	
	public void hit_area(Area2D area)
	{
		damage = true
	while (damage)
		GD.Print("enemy zone");
		health-=1;
	}
	
	public void OnKill()
	{
		GD.Print("killed");
		QueueFree();

	}
}
