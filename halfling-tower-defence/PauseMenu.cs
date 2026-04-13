using Godot;

public partial class PauseMenu : Control
{
	[Export] public string MainMenuScenePath = "res://Scenes/MainMenu.tscn";

	public override void _Ready()
	{
		ProcessMode = Node.ProcessModeEnum.WhenPaused;
		Hide();
	}

	public void ShowMenu()
	{
		Show();
	}

	public void HideMenu()
	{
		Hide();
	}

	public void _on_resume_button_pressed()
	{
		GetTree().Paused = false;
		Hide();
	}

	public void _on_exit_button_pressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile(MainMenuScenePath);
	}
}
