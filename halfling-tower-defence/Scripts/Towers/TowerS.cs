using Godot;
using System;


public partial class TowerS : Tower
{
	[Export] public CollisionShape2D Scalleywag_hit { get; set; }
	[Export] public Timer Scalleywag_attack_speed { get; set; }
	[Export] public int damageAmount= 5;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}
	
	
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
