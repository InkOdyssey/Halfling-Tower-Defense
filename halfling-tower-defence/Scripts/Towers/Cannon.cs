using Godot;
using System;

public partial class Cannon : Tower
{
	[Export] public CollisionShape2D Cannon_hit { get; set; }
	[Export] public Timer Cannon_attack_speed { get; set; }
	[Export] public int damageAmount= 75;
	public override void _Ready()
	{

		base._Ready();
	}
	
	
	
	
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
