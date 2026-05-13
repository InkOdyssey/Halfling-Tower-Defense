using Godot;
using System;

public partial class WaveButton : Control
{
	private Node2D map;
	private Node2D create_spawner1;
	private Node2D create_spawner2;
	private Node2D create_spawner3;
	private Node2D create_spawner4;
	private Timer timer;
	private bool wave_over = true;
	
	private PackedScene spawner1 = GD.Load<PackedScene>("res://Scenes/Enemies/spawner1.tscn");
	private PackedScene spawner2 = GD.Load<PackedScene>("res://Scenes/Enemies/spawner2.tscn");
	private PackedScene spawner3 = GD.Load<PackedScene>("res://Scenes/Enemies/spawner3.tscn");
	private PackedScene spawner4 = GD.Load<PackedScene>("res://Scenes/Enemies/spawner4.tscn");
	
	[Export] public int wave = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Node2D>("/root/map/");
		create_spawner1 = spawner1.Instantiate<Node2D>();
		create_spawner2 = spawner2.Instantiate<Node2D>();
		create_spawner3 = spawner3.Instantiate<Node2D>();
		create_spawner4 = spawner4.Instantiate<Node2D>();
		timer = GetNode<Timer>("Timer");
		timer.Timeout += _on_timer_timeout;
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
			timer.Start();
			wave_over = false;
			GD.Print("wave 1 started");
			GameManager.Instance.CurrentWaves = wave;
		}
	private void wave_2()
		{
			var create_spawner2a = spawner2.Instantiate<Node2D>();
			
			map.AddChild(create_spawner2a);
			timer.Start();
			wave_over = false;
			GD.Print("wave 2 started");
			GameManager.Instance.CurrentWaves = wave;
		}
	private void wave_3()
		{
			var create_spawner1b = spawner1.Instantiate<Node2D>();
			var create_spawner2b = spawner2.Instantiate<Node2D>();
			var create_spawner3a = spawner3.Instantiate<Node2D>();
			
			map.AddChild(create_spawner3a);
			timer.Start();
			wave_over = false;
			GD.Print("wave 3 started");
			GameManager.Instance.CurrentWaves = wave;
		}
	private void wave_4()
	{
		map.AddChild(create_spawner4);
		timer.Start();
		wave_over = false;
		GD.Print("wave 4 started");
		GameManager.Instance.CurrentWaves = 4;
	}
	private void wave_5()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Win.tscn");
		wave += 1;
		wave_over = false;
		GD.Print("wave 5 started");
	}
	private void wave_6()
	{
		wave += 1;
		GD.Print("Wave 6 started");
	}
	
	
	
	private void _on_button_pressed()
		{
			GD.Print("Button Pressed");
			
			if (wave_over == true)
			{
			switch (wave)
			{
				case 0:
					wave_1();
					break;
				case 1:
					wave_2();
					break;
				case 2:
					wave_3();
					break;
				case 3:
					wave_4();
					break;
				case 4:
					wave_5();
					break;
				case 5:
					wave_6();
					break;
			}
			}
			
			
		}
		private void _on_timer_timeout()
		{
			wave += 1;
			wave_over = true;
		}
}
