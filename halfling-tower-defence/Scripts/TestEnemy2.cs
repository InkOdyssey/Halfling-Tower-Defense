using Godot;
using System;

public partial class TestEnemy2 : CharacterBody2D
{

	//assigns pathprogress as a variable, but no value
	private PathFollow2D pathprogress;
	private int health = 3000;
	private Area2D hitArea;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hitArea = GetNode<Area2D>("hit_area");
		//gives pathprogress a value
		pathprogress = GetParent<PathFollow2D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
		if (pathprogress.ProgressRatio < 1.0f)
			{
				pathprogress.ProgressRatio += .0006f;
			}
		else if (pathprogress.ProgressRatio == 1.0f)
			{
				GD.Print("freed");
				QueueFree();
			}}


	public void Damage() 
	{
		var bodies = hitArea.GetOverlappingAreas();
		foreach (var body in bodies)
		{
			if (body is DetectorS)
			{
				health -= 1;
				GD.Print("this is king ");

				if (health < 1)
				{
					QueueFree();
				}
			}

			else if (body is Detector)
			{
				health -= 10000;
				GD.Print(health);
				GD.Print("blackbeard damage");
				if (health < 1)
				{
					QueueFree();
				}

			}	
		}}



	
	
	private void OnKill()
	{
		GD.Print("killed");
		QueueFree();
		
	}



}
