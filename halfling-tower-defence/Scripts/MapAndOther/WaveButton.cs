using Godot;
using System;

public partial class WaveButton : Control
{
	private Node2D map;

	
	private int wave = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		map = GetNode<Node2D>("/root/map/");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	
	private void wave_1()
		{

			wave += 1;
			GD.Print("wave 1 started");
		}
	private void wave_2()
		{

			wave += 1;
			GD.Print("wave 2 started");
		}
	private void wave_3()
		{
			wave += 1;
		}
	
	
	
	
	private void _on_button_pressed()
		{
			GD.Print("Button Pressed");
			
			if (wave == 1)
				{
					wave_1();
				}
			else if (wave == 2)
				{
					wave_2();
				}
			else if (wave == 3)
				{
					wave_3();
				}
			
		}
}
