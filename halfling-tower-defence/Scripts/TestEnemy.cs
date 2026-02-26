using Godot;
using System;

public partial class TestEnemy : CharacterBody2D
{
	
	private int health = 3;
	private bool damage = false;
	

	//assigns pathprogress as a variable, but no value
	private PathFollow2D pathprogress;
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
		
		//gives pathprogress a value
		pathprogress = GetParent<PathFollow2D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (health < 1)
		{
			QueueFree();
		}
		
		
		if (pathprogress.ProgressRatio < 1.0f)
			{
				pathprogress.ProgressRatio += .001f;
			}
		else if (pathprogress.ProgressRatio == 1.0f)
			{
				GD.Print("freed");
				QueueFree();
			}
			
	}
	
	public void hit_area(Area2D area)
	{
		damage = true;
	while (damage)
		GD.Print("enemy zone");
		health-=1;
	}
	
	public void OnKill()
	{
		GD.Print("killed");
		QueueFree();

	}
}
