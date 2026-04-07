using Godot;

public partial class MainGame : Node
{
	[Export] public NodePath PauseMenuPath;

	private Control _pauseMenu;

	public override void _Ready()
	{
		_pauseMenu = GetNode<Control>(PauseMenuPath);
		_pauseMenu.Hide();
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("pause_game"))
		{
			TogglePause();
		}
	}

	private void TogglePause()
	{
		bool paused = GetTree().Paused;
		GetTree().Paused = !paused;
		_pauseMenu.Visible = !paused;
	}
}
