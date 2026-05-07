using Godot;

public partial class Upgrades : Control
{
	private Panel _upgrade;

	public override void _Ready()
	{
		_upgrade = GetNode<Panel>("Upgrade_panel");
		_upgrade.Hide();
	}

	private void _on_blackbeard_upgrade_pressed() => _upgrade.Show();
	private void _on_bomber_upgrade_pressed() => _upgrade.Show();
	private void _on_cannon_upgrade_pressed() => _upgrade.Show();
	private void _on_pirateship_upgrade_pressed() => _upgrade.Show();
	private void _on_scalleywag_upgrade_pressed() => _upgrade.Show();
}
