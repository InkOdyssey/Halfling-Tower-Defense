using Godot;
using System;

public partial class Tower : Node2D
{
protected Area2D hitArea;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		GD.Print("test");
		hitArea = GetNode<Area2D>("hit_area");
	}


	public void in_range(Area2D area)
	{
		GD.Print("zone base tower");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public virtual void ApplyDamage()
	{
		var bodies = hitArea.GetOverlappingBodies();
		foreach (var body in bodies)
		{
			if (body is TestEnemy enemy)
			{
				enemy.ApplyDamage(5);
				return;
			}
			if (body is TeaCup Tea)
			{
				Tea.ApplyDamage(1);
				return;
			}
			
		}
	}

	}
	
