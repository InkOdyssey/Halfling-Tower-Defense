using Godot;
using System;

public partial class TestTower2Button : Control
{
	private Map map;
	private PackedScene test_tower_2 = GD.Load<PackedScene>("res://Scenes/test_tower_2.tscn");
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Map>("/root/map");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	
	private void _on_button_pressed()
		{
			map.StartPlacingBlackbeard();
		}
}
