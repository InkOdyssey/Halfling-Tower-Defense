using Godot;

public partial class GameOver : Node
{
	private LineEdit _nameInput;
	private Label _wavesLabel;

	public override void _Ready()
	{
		_nameInput = GetNode<LineEdit>("NameInput");
		_wavesLabel = GetNode<Label>("WavesLabel");
		UpdateWavesDisplay();
	}

	private void UpdateWavesDisplay()
	{
		int waves = GameManager.Instance.GetCurrentWaves();
		_wavesLabel.Text = $"Waves Survived: {waves}";
	}

	private void _on_main_menu_pressed()
	{
		string playerName = _nameInput.Text.Trim();
		if (string.IsNullOrWhiteSpace(playerName))
			playerName = "Anonymous";

		GameManager.Instance.SubmitScore(playerName, GameManager.Instance.GetCurrentWaves());
		GetTree().ChangeSceneToFile("res://Scenes/Other/Start_Menu.tscn");
		
	}
}
