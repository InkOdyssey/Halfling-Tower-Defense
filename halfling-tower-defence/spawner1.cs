using Godot;
using System;

public partial class spawner1 : Node2D
{
	private Timer timer1;
	private Timer timer2;
	private int enemy1_count = 0;
	private int enemy2_count = 0;
	
	
	private PackedScene test_enemy = GD.Load<PackedScene>("res://Scenes/test_enemy.tscn");
	private PackedScene test_enemy_2 = GD.Load<PackedScene>("res://Scenes/test_enemy_2.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer1 = GetNode<Timer>("Timer1");
		timer2 = GetNode<Timer>("Timer2");
		timer1.Start();
		timer2.Start();
		timer1.Timeout += _on_timer1_timeout;
		timer2.Timeout += _on_timer2_timeout;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_timer1_timeout()
	{
		GD.Print("timeout");
		
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var test_enemy_spawn = test_enemy.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		
		
		if (enemy1_count <= 10)
		{
			enemypath.AddChild(new_enemypath);
			new_enemypath.AddChild(test_enemy_spawn);
			enemy1_count += 1;
		}
	}
	
	
	private void _on_timer2_timeout()
	{
		var test_enemy_2_spawn = test_enemy_2.Instantiate<CharacterBody2D>();
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var test_enemy_spawn = test_enemy.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		
		
		if (enemy2_count <= 5)
		{
			enemypath.AddChild(new_enemypath);
			new_enemypath.AddChild(test_enemy_2_spawn);
			enemy2_count += 1;
		}
	}
	
}
