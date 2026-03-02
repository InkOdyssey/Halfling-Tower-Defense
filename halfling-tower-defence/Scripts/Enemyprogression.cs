using Godot;
using System;

public partial class Enemyprogression : PathFollow2D
{
	
	public float Speed = 300f;
	private bool Killed = false;
	
	
	[Signal]
	public delegate void KillEventHandler();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
		if (ProgressRatio < 1.0f)
			{
				ProgressRatio += .001f;
			}
		else if (ProgressRatio == 1.0f && Killed == false)
			{
				GD.Print("finished");
				Killed = !Killed;
			}
	}
}
