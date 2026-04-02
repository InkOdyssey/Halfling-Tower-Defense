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
		GD.Print("BlackBeard zone");
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	public virtual void ApplyDamage()
	{
		var bodies = hitArea.GetOverlappingAreas();
		foreach (var body in bodies);
	}
	}
	
