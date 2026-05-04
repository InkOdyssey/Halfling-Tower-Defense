using Godot;
using System;

public partial class Tower : Node2D
{
	protected Area2D hitArea;
	protected Marker2D StartPoint;


	[Export] public PackedScene TowerBullet;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		GD.Print("test");
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
	}

}
