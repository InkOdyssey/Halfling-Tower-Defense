using Godot;
using System;

public partial class Jester : CharacterBody2D
{
	
	
	private int health = 400;
	private bool damage = false;
	private Area2D hitArea;
	private bool _isDead = false;


	

	//assigns pathprogress as a variable, but no value
	private PathFollow2D pathprogress;



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
			OnKill();
			return;
}
		
		
		if (pathprogress.ProgressRatio < 1.0f)
			{
				pathprogress.ProgressRatio += .0008f;
			}
		else if (pathprogress.ProgressRatio >= 1.0f)
			{
				GD.Print("freed");
				QueueFree();
				if (GameManager.Instance != null)
					GameManager.Instance.LoseHearts(15);
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

	public void hit_area_leave(Area2D area)
	{
		GD.Print("enemy zone inactive");
	}
	
	private void OnKill()
{
		if (_isDead) return;
			_isDead = true;

		GD.Print("Enemy killed");

		if (GameManager.Instance != null)
			GameManager.Instance.AddCoins(50);
		else
			GD.PrintErr("GameManager is NULL on kill!");

		QueueFree();
}
	}
