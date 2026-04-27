using Godot;
using System;

public partial class TestEnemy : CharacterBody2D
{
	
	protected int health = 15;
	protected bool damage = false;
	protected Area2D hitArea;
	protected Sprite2D sprite;

	//assigns pathprogress as a variable, but no value
	public PathFollow2D pathprogress;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gives pathprogress a value
		if (pathprogress is null)
			pathprogress = GetParent<PathFollow2D>();
		hitArea = GetNode<Area2D>("hit_area");
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
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





	public void ApplyDamage(int damage)
	{
		health -= damage;
		GD.Print(health);
		sprite.SelfModulate = new Color(1f, 0.5f, 0.5f, 1f);
		if (health <= 0)
			OnKill();
			
	}

	public virtual void hit_area_leave(Area2D area)
	{
	}
	
	public virtual void OnKill()
	{
		QueueFree();
	}
}
