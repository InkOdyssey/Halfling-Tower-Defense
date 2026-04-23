using Godot;
using System;

public partial class WaveButton : Control
{
	private Node2D map;
	private Node2D create_spawner1;
	private Node2D create_spawner2;
	
	
	private PackedScene spawner1 = GD.Load<PackedScene>("res://Scenes/spawner1.tscn");
	private PackedScene spawner2 = GD.Load<PackedScene>("res://Scenes/spawner2.tscn");
	
	[Export] public int wave = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Node2D>("/root/map/");
		create_spawner1 = spawner1.Instantiate<Node2D>();
		create_spawner2 = spawner2.Instantiate<Node2D>();
	}
	[Signal] public delegate void WaveStartedEventHandler(int waveNumber);

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
			GameManager.Instance.CurrentWaves = wave;
		}
	private void wave_2()
		{
			var create_spawner2a = spawner2.Instantiate<Node2D>();
			
			map.AddChild(create_spawner2a);
			wave += 1;
			GD.Print("wave 2 started");
			GameManager.Instance.CurrentWaves = wave;
		}
	private void wave_3()
		{
			var create_spawner1b = spawner1.Instantiate<Node2D>();
			var create_spawner2b = spawner2.Instantiate<Node2D>();
			
			map.AddChild(create_spawner1b);
			map.AddChild(create_spawner2b);
			wave += 1;
			GD.Print("wave 3 started");
			GameManager.Instance.CurrentWaves = wave;
		}
	
	
	
	
	private void _on_button_pressed()
		{
			GD.Print("Button Pressed");
			
			if (wave == 0)
				{
					wave_1();
				}
			else if (wave == 1)
				{
					wave_2();
				}
			else if (wave == 2)
				{
					wave_3();
				}
			
		}
}
