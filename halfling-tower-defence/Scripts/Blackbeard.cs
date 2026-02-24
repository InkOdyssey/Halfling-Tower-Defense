using Godot;
using System;

public partial class Blackbeard : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
	}
	
	
		public void in_range(Node2D body)
	{
		GD.Print("in zone");
		
		if(body is Enemy)
		{
			QueueFree();
		}
			
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
