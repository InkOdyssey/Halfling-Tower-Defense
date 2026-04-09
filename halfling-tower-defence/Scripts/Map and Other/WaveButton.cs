using Godot;
using System;

public partial class WaveButton : Control
{
	private Node2D map;

	
	private int wave = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Node2D>("/root/map/");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void wave_1()
		{

			var create_spawner1a = spawner1.Instantiate<Node2D>();
			
			map.AddChild(create_spawner1a);
			wave += 1;
			GD.Print("wave 1 started");
		}
	private void wave_2()
		{

			var create_spawner2a = spawner2.Instantiate<Node2D>();
			
			map.AddChild(create_spawner2a);
			wave += 1;
			GD.Print("wave 2 started");
		}
	private void wave_3()
		{
			var create_spawner1b = spawner1.Instantiate<Node2D>();
			var create_spawner2b = spawner2.Instantiate<Node2D>();
			
			map.AddChild(create_spawner1b);
			map.AddChild(create_spawner2b);
			wave += 1;
			GD.Print("wave 3 started");
		}
	
	
	
	
	private void _on_button_pressed()
		{
			GD.Print("Button Pressed");
			
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
