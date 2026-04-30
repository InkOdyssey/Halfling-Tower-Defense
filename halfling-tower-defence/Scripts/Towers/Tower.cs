using Godot;
using System;

public partial class Tower : CharacterBody2D
{
	//protected means that the variable/method can be used in this class (tower) and those that inherit from it
	//like the scallelywag and other towers
protected Area2D hitArea;
protected int damageAmount = 10;

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
		
		GD.Print("Bodies found: " + bodies.Count);
		
		foreach (var body in bodies)
		{
			if (body is Tea_Cup tea)
			{
				tea.ApplyDamage(damageAmount);
				return;
			}
			else if (body is TeaCrate crate)
			{
				crate.ApplyDamage(damageAmount);
				return;
			}
			else if (body is Flag flag)
			{
				flag.ApplyDamage(damageAmount);
				return;
			}
			
		}
	}

	}
	
