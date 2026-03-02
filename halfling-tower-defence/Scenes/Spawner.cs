using Godot;
using System;

public partial class Spawner : Node2D
{
	private Timer timer;
	
	
	private PackedScene test_enemy = GD.Load<PackedScene>("res://Scenes/test_enemy.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.Start();
		timer.Timeout += _on_timer_timeout;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_timer_timeout()
	{
		GD.Print("timeout");
		
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var test_enemy_spawn = test_enemy.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.ProgressRatio = 0f;
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		enemypath.AddChild(new_enemypath);
		new_enemypath.AddChild(test_enemy_spawn);
	}
	
}
