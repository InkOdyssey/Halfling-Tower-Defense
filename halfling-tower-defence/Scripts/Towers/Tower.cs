using Godot;
using System;

public partial class Tower : CharacterBody2D
{
	protected Area2D hitArea;
	protected Marker2D StartPoint;
	//protected means that the variable/method can be used in this class (tower) and those that inherit from it
	//like the scallelywag and other towers
	protected int damageAmount = 10;


	[Export] public PackedScene TowerBullet;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		hitArea = GetNode<Area2D>("hit_area");
		StartPoint = GetNode<Marker2D>("Marker2D");
	}


	public void timeout()
	{
		
		GD.Print("zone base tower");
		var bodies = hitArea.GetOverlappingBodies();
		foreach (var body in bodies)
		{
			var bullet = TowerBullet.Instantiate<Bullet>();
			bullet.GlobalPosition = StartPoint.GlobalPosition;
			bullet.target = body.GlobalPosition;
			CallDeferred("add_child", bullet);
			return;

		}
		if (TowerBullet == null)
		{
   			GD.PrintErr("TowerBullet is not assigned!");
			return;
		}
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
