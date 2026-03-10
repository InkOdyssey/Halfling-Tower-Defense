using Godot;
using System;

public partial class TestEnemy2 : CharacterBody2D
{
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
	
	private void OnKill()
	{
		GD.Print("killed");
		QueueFree();
		
	}
}
