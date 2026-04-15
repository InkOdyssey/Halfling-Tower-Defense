using Godot;
using System;
public partial class test_tower : CharacterBody2D
{
	private bool placed = false;
	private bool moveable = true;
	private int clicks = 0;
	
	
	private Area2D tower_hitbox;
	private Node2D placement_area;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		tower_hitbox = GetNode<Area2D>("hitbox");
		placement_area = GetNode<Node2D>("/root/map/placement_area");
		
	}
	
	
	
public override void _PhysicsProcess(double delta)
	{
		if (!placed && moveable)
		{
			GlobalPosition = GetGlobalMousePosition();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
		
		
		
		
		if (Input.IsActionJustPressed("place_tower"))
			{
				var overlapping = tower_hitbox.GetOverlappingAreas();
				
				
				if (clicks == 0 && overlapping.Count == 0)
				{
					GD.Print("placed");
					placed = !placed;
					clicks += 1;
				}
				else
				{
					GD.Print("overlapping");
				}
			}
	}
	
	
}
