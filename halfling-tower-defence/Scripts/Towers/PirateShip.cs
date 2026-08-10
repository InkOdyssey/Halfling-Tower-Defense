using Godot;
using System;

public partial class PirateShip : Tower
{
	[Export] public CollisionShape2D Pirateship_hit { get; set; }
	[Export] public Timer Pirateship_attack_speed { get; set; }
	[Export] public int damageAmount= 45;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
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
