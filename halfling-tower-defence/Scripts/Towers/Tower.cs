using Godot;
using System;

public partial class Tower : CharacterBody2D
{
	//protected means that the variable/method can be used in this class (tower) and those that inherit from it
	//like the scallelywag and other towers
protected Area2D hitArea;
protected int damageAmount = 20;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
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
		
		CharacterBody2D target = null;
		float highestProgress = -1f;
		
		foreach (var body in bodies)
		{
			if (body is Tea_Cup tea)
			{
				PathFollow2D pathFollow = tea.GetParent<PathFollow2D>();
				
				if (pathFollow.ProgressRatio > highestProgress)
				{
					highestProgress = pathFollow.ProgressRatio;
					target = tea;
				}
			}
			else if (body is TeaCrate crate)
			{
				PathFollow2D pathFollow = crate.GetParent<PathFollow2D>();
				
				if (pathFollow.ProgressRatio > highestProgress)
				{
					highestProgress = pathFollow.ProgressRatio;
					target = crate;
				}
			}
			else if (body is Flag flag)
			{
				PathFollow2D pathFollow = flag.GetParent<PathFollow2D>();
				
				if (pathFollow.ProgressRatio > highestProgress)
				{
					highestProgress = pathFollow.ProgressRatio;
					target = flag;
				}
			}
			else if (body is Jester jester)
			{
				PathFollow2D pathFollow = jester.GetParent<PathFollow2D>();
				
				if (pathFollow.ProgressRatio > highestProgress)
				{
					highestProgress = pathFollow.ProgressRatio;
					target = jester;
				}
			}
			else if (body is KingGeorgeIii king)
			{
				PathFollow2D pathFollow = king.GetParent<PathFollow2D>();
				
				if (pathFollow.ProgressRatio > highestProgress)
				{
					highestProgress = pathFollow.ProgressRatio;
					target = king;
				}
			}
			
			
			
		}
		if (target is Tea_Cup targetTea)
			{
				targetTea.ApplyDamage(damageAmount);
				return;
			}
			else if (target is TeaCrate targetCrate)
			{
				targetCrate.ApplyDamage(damageAmount);
				return;
			}
			else if (target is Flag targetFlag)
			{
				targetFlag.ApplyDamage(damageAmount);
				return;
			}
			else if (target is Jester targetJester)
			{
				targetJester.ApplyDamage(damageAmount);
				return;
			}
			else if (target is KingGeorgeIii targetKing)
			{
				targetKing.ApplyDamage(damageAmount);
				return;
			}
	}

	}
	
