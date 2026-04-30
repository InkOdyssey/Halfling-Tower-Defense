using Godot;
using System;

public partial class TestEnemy : CharacterBody2D
{
	
	protected int health = 15;
	protected bool damage = false;
	protected Area2D hitArea;
	private bool _isDead = false;

	//assigns pathprogress as a variable, but no value
	public PathFollow2D pathprogress;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//gives pathprogress a value
		if (pathprogress is null)
			pathprogress = GetParent<PathFollow2D>();
		hitArea = GetNode<Area2D>("hit_area");
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
				QueueFree();
				if (GameManager.Instance != null)
					GameManager.Instance.LoseHearts(10);
				else
					GD.PrintErr("GameManager.Instance is NULL!");
				
			}
			
	}





	public void ApplyDamage(int damage)
	{
		health -= damage;
		GD.Print(health);
		if (health <= 0)
			OnKill();
	}

	public virtual void hit_area_leave(Area2D area)
	{
	}
	
	private void OnKill()
{
		if (_isDead) return;
			_isDead = true;

		GD.Print("Enemy killed");

		if (GameManager.Instance != null)
			GameManager.Instance.AddCoins(10);
		else
			GD.PrintErr("GameManager is NULL on kill!");

		QueueFree();
	}
}
