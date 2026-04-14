using Godot;
using System;

public partial class TestEnemy2 : TestEnemy
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		health = 3000;
		//call the _Ready function in 'TestEnemy'
		base._Ready();
	}

	public void ApplyDamage()
	{
		GD.Print(hitArea.GetOverlappingAreas().Count);
		base.ApplyDamage(1);
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{


		if (pathprogress.ProgressRatio < 1.0f)
		{
			pathprogress.ProgressRatio += .0006f;
		}
		else if (pathprogress.ProgressRatio == 1.0f)
		{
			GD.Print("freed");
			QueueFree();
		}
	}




	public override void hit_area_leave(Area2D area)
	{
	}

	
	
	public override void OnKill()
	{
		GD.Print("killed");
		QueueFree();
		
	}



}
