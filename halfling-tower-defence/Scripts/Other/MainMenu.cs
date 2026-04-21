using Godot;
using System;

public partial class MainMenu : Control{
	public override void _Ready(){
		GetNode<Button>("Start_Button").Pressed +=_Play;
		GetNode<Button>("End_Button").Pressed += _Quit;
	}

	private void _Play() {
		GetTree().ChangeSceneToFile("res://Scenes/Map/map.tscn");
	}
	
	public override void _Process(double delta)
	{
		
	}
	
	private void _Quit () {
		GetTree().Quit();
	}
}
