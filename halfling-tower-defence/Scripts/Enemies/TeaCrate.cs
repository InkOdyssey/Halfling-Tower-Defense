using Godot;
using System;

public partial class TeaCrate : CharacterBody2D
{
	private int health = 45;
	private bool damage = false;
	private Area2D hitArea;
	private bool _isDead = false;
	
	private RandomNumberGenerator _rng = new RandomNumberGenerator();
	
	private PackedScene tea = GD.Load<PackedScene>("res://Scenes/Enemies/tea.tscn");
	
	
	//assigns pathprogress as a variable, but no value
	private PathFollow2D pathprogress;
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("test");
	}
	
	public override void _Process(double delta)
	{
		
	}
}
