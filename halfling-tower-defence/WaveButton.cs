using Godot;
using System;

public partial class WaveButton : Control
{
	private Node2D map;
	private Node2D create_spawner1;
	private Node2D create_spawner2;
	
	
	private PackedScene spawner1 = GD.Load<PackedScene>("res://Scenes/spawner1.tscn");
	private PackedScene spawner2 = GD.Load<PackedScene>("res://Scenes/spawner2.tscn");
	
	private int wave = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Node2D>("/root/map/");
		create_spawner1 = spawner1.Instantiate<Node2D>();
		create_spawner2 = spawner2.Instantiate<Node2D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void wave_1()
		{
			map.AddChild(create_spawner1);
			wave += 1;
			GD.Print("wave 1 started");
		}
	private void wave_2()
		{
			map.AddChild(create_spawner2);
			wave += 1;
			GD.Print("wave 2 started");
		}
	private void wave_3()
		{
			wave += 1;
		}
	
	
	
	
	private void _on_button_pressed()
		{
			if (wave == 1)
				{
					wave_1();
				}
			else if (wave == 2)
				{
					wave_2();
				}
			else if (wave == 3)
				{
					wave_3();
				}
			
		}
}
