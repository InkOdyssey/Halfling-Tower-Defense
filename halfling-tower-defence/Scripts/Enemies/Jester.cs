using Godot;
using System;

public partial class Jester : CharacterBody2D
{
	public override void _Ready()
	{
		GD.Print("test");
	}
	
	public override void _Process(double delta)
	{
		
	}
}
