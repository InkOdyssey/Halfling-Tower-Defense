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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (placed == false & moveable == true)
		{
			GlobalPosition = GetGlobalMousePosition();
		}
		
		
		
		
		
		
		if (Input.IsActionJustPressed("place_tower"))
			{
				if (clicks == 0)
				{
					GD.Print("placed");
					placed = !placed;
					clicks += 1;
				}
			}
	}
	
	
}
