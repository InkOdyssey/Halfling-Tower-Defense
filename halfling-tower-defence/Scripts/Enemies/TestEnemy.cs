using Godot;
using System;

public partial class TestEnemy : CharacterBody2D
{
	
	protected int health = 300;
	protected bool damage = false;
	protected Area2D hitArea;

	//assigns pathprogress as a variable, but no value
	protected PathFollow2D pathprogress;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gives pathprogress a value
		pathprogress = GetParent<PathFollow2D>();
		hitArea = GetNode<Area2D>("hit_area");
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
	


	

	public virtual void ApplyDamage() 
	{
		var bodies = hitArea.GetOverlappingAreas();
		foreach (var body in bodies)
		{
			if (body is DetectorS)
			{
				health -= 1;
				if (health < 1)
				{
					damage = false;
					QueueFree();
				}
			}

			else if (body is Detector)
			{
				health -= 10000;
				GD.Print(health);
				GD.Print("blackbeard damage");
				if (health < 1)
				{
					damage = false;
					QueueFree();
				}

			}	


			
		}
	}

	public virtual void hit_area_leave(Area2D area)
	{
	}
	
	public virtual void OnKill()
	{
		GD.Print("killed");
		QueueFree();

	}
}
