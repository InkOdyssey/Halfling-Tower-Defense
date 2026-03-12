using Godot;
using System;

public partial class PlacementArea : Node2D
{
	private Area2D placement;
	public bool tower_in_area = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		placement = GetNode<Area2D>("placement");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	private void _on_placement_area_entered(Area2D area)
	{
		GD.Print("hitbox entered");
		tower_in_area = true;
	}
	private void _on_placement_area_exited(Area2D area)
	{
		GD.Print("hitbox exited");
		tower_in_area = false;
	}
	
	private void _on_placement_mouse_entered(Area2D area)
	{
		GD.Print("mouse entered");
	}
}
