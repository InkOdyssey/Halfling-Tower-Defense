using Godot;
using System;

public partial class spawner2 : Node2D
{
	private Timer timer2;
	
	
	private PackedScene test_enemy_2 = GD.Load<PackedScene>("res://Scenes/test_enemy_2.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer2 = GetNode<Timer>("Timer2");
		timer2.Start();
		timer2.Timeout += _on_timer_timeout;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_timer_timeout()
	{
		GD.Print("timeout");
		
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var test_enemy_spawn = test_enemy_2.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.ProgressRatio = 0f;
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		enemypath.AddChild(new_enemypath);
		new_enemypath.AddChild(test_enemy_spawn);
	}
	
}
