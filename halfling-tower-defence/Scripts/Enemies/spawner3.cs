using Godot;
using System;

public partial class spawner3 : Node2D
{
	private Timer timer1;
	private Timer timer2;
	private Timer timer3;
	private int enemy1_count = 0;
	private int enemy2_count = 0;
	private int enemy3_count = 0;
	
	private PackedScene tea = GD.Load<PackedScene>("res://Scenes/Enemies/tea.tscn");
	private PackedScene tea_crate = GD.Load<PackedScene>("res://Scenes/Enemies/tea_crate.tscn");
	private PackedScene flag = GD.Load<PackedScene>("res://Scenes/Enemies/flag.tscn");
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer1 = GetNode<Timer>("Timer1");
		timer2 = GetNode<Timer>("Timer2");
		timer3 = GetNode<Timer>("Timer3");
		timer1.Timeout += _on_timer1_timeout;
		timer2.Timeout += _on_timer2_timeout;
		timer3.Timeout += _on_timer3_timeout;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void _on_timer1_timeout()
	{
		GD.Print("timeout");
		
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var tea_spawn = tea.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		
		if (enemy1_count <= 30)
		{
			enemypath.AddChild(new_enemypath);
			new_enemypath.AddChild(tea_spawn);
			enemy1_count += 1;
		}
	}
	
	
	private void _on_timer2_timeout()
	{
		var tea_crate_spawn = tea_crate.Instantiate<CharacterBody2D>();
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var tea_spawn = tea.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		
		
		if (enemy2_count <= 8)
		{
			enemypath.AddChild(new_enemypath);
			new_enemypath.AddChild(tea_crate_spawn);
			enemy2_count += 1;
		}
	}
	
	
	private void _on_timer3_timeout()
	{
		var flag_spawn = flag.Instantiate<CharacterBody2D>();
		var enemypath = GetNode<Path2D>("/root/map/Path2D");
		var tea_spawn = tea.Instantiate<CharacterBody2D>();
		
		var new_enemypath = new PathFollow2D();
		new_enemypath.Loop = false;
		new_enemypath.Rotates = false;
		
		
		if (enemy3_count <= 5)
		{
			enemypath.AddChild(new_enemypath);
			new_enemypath.AddChild(flag_spawn);
			enemy3_count += 1;
		}
	}
}
