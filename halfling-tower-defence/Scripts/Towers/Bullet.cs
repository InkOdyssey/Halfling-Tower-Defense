using Godot;
using System;


public partial class Bullet : Tower
{
public float Speed = 1000f;
public Vector2 target;
private Area2D hitArea;
	
	public override void _Ready()
	{
	Vector2 direction = (target - GlobalPosition).Normalized();
	hitArea = GetNode<Area2D>("hit_area");
	}
public virtual void ApplyDamage()
	{
		var bodies = hitArea.GetOverlappingBodies();
		foreach (var body in bodies)
		{
			if (body is TestEnemy Enemy)
			{
				//replace the apply damage function with bullet.Instantiate()
				//then have the bullet chase the enemy and apply damage once they hit each other
				Enemy.ApplyDamage(5);
				return;
			}
		}
		}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	 Vector2 direction = (target - GlobalPosition).Normalized();
	 Vector2 movement = direction * Speed * (float)delta;
	 GlobalPosition += movement;
	if (GlobalPosition <= target)
	{
		QueueFree();
	}
}
}
