using Godot;
using System;

public partial class Tea_Cup : CharacterBody2D
{
	private int health = 300;
	private bool damage = false;
	private Area2D hitArea;
	private bool _isDead = false;
	protected Sprite2D sprite;
	private Timer timer;
	

	//assigns pathprogress as a variable, but no value
	private PathFollow2D pathprogress;



	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		timer.Timeout += _on_timer_timeout;
		//gives pathprogress a value
		pathprogress = GetParent<PathFollow2D>();
		hitArea = GetNode<Area2D>("hit_area");
		sprite = GetNode<Sprite2D>("Sprite2D");
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
				pathprogress.ProgressRatio += .0006f;
			}
		else if (pathprogress.ProgressRatio >= 1.0f)
			{
				GD.Print("freed");
				QueueFree();
				if (GameManager.Instance != null)
					GameManager.Instance.LoseHearts(5);
				else
					GD.PrintErr("GameManager.Instance is NULL!");
			}
			
	}
	


	

	public void ApplyDamage(int damage)
	{
		health -= damage;
		GD.Print(health);
		sprite.SelfModulate = new Color(1.5f, .5f, .5f, 1f);
		timer.Start();
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
			GameManager.Instance.AddCoins(10);
		else
			GD.PrintErr("GameManager is NULL on kill!");

		QueueFree();
}
	private void _on_timer_timeout()
	{
		sprite.SelfModulate = new Color(1f, 1f, 1f, 1f);
	}
}
