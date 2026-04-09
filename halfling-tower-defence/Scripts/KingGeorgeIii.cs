using Godot;
using System;

public partial class KingGeorgeIii : CharacterBody2D
{
	
	private int health = 1000;
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
				pathprogress.ProgressRatio += .0005f;
			}
		else if (pathprogress.ProgressRatio >= 1.0f)
			{
				GD.Print("freed");
				QueueFree();
				if (GameManager.Instance != null)
					GameManager.Instance.LoseHearts(100);
				else
					GD.PrintErr("GameManager.Instance is NULL!");
			}
			
	}
	


	

	public void ApplyDamage() 
	{
		var bodies = hitArea.GetOverlappingAreas();
		foreach (var body in bodies)
		{
			if (body is DetectorS)
			{
				health -= 1;
				GD.Print(health);
				if (health < 1)
				{
					damage = false;
					OnKill();
				}
			}

			else if (body is Detector)
			{
				health -= 10000;
				GD.Print(health);
				GD.Print("blackbeard damage");
				if (health < 1)
				{
					damage = false;
					OnKill();
				}

			}	


			
		}
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
			GameManager.Instance.AddCoins(500);
		else
			GD.PrintErr("GameManager is NULL on kill!");

		QueueFree();
}
	}
