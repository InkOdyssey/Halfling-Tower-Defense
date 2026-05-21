using Godot;

public partial class Upgrades : Control
{
	private Panel _upgrade;

	public override void _Ready()
	{
		_upgrade = GetNode<Panel>("Upgrade_panel");
		_upgrade.Hide();
	}
	private void Blackbeard_Range_up()
{
		Tower tower = GetNode<Tower>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(60))
{
		CollisionShape2D hitbox1 = tower.Blackbeard_hit;
		hitbox1.Scale = new Vector2(1.5f, 1.5f);
}


}
private void Bomber_Range_up()
{
	Bomber tower = GetNode<Bomber>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(60))
{
	CollisionShape2D hitbox2 = tower.Bomber_hit;
	hitbox2.Scale = new Vector2(1.5f, 1.5f);
}}
private void Cannon_Range_up()
{
	Cannon tower = GetNode<Cannon>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(60))
{
	CollisionShape2D hitbox3 = tower.Cannon_hit;
	hitbox3.Scale = new Vector2(1.5f, 1.5f);
	}}

	private void Pirateship_Range_up()
{
	PirateShip tower = GetNode<PirateShip>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(60))
{
		CollisionShape2D hitbox4 = tower.Pirateship_hit;
		hitbox4.Scale = new Vector2(1.5f, 1.5f);
}}
private void Scalleywag_Range_up()
{
	TowerS tower = GetNode<TowerS>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(60))
{
		CollisionShape2D hitbox5 = tower.Scalleywag_hit;
		hitbox5.Scale = new Vector2(1.5f, 1.5f);
}}
private void Cannon_fire_speed_up()
{
	Cannon tower = GetNode<Cannon>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(80))
{
		Timer speed1 = tower.Cannon_attack_speed;
		speed1.WaitTime = 2f;
		speed1.Start();
}}
private void Bomber_fire_speed_up()
{
	Bomber tower = GetNode<Bomber>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(80))
{
		Timer speed2 = tower.Bomber_attack_speed;
		speed2.WaitTime = 1f;
		speed2.Start();
}}
private void Blackbeard_fire_speed_up()
{
	Tower tower = GetNode<Tower>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(80))
{
		Timer speed3 = tower.Blackbeard_attack_speed;
		speed3.WaitTime = 0.64f;
		speed3.Start();
}}
private void Scalleywag_fire_speed_up()
{
	TowerS tower = GetNode<TowerS>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(80))
{
		Timer speed4 = tower.Scalleywag_attack_speed;
		speed4.WaitTime = 0.4f;
		speed4.Start();
}}
private void Pirateship_fire_speed_up()
{
	PirateShip tower = GetNode<PirateShip>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(80))
{
		Timer speed5 = tower.Pirateship_attack_speed;
		speed5.WaitTime = 1f;
		speed5.Start();
}}
private void Blackbeard_damage_up()
{
	Tower tower = GetNode<Tower>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(90))
{
	 tower.damageAmount += 5;
}}
private void Scalleywag_damage_up()
{
	TowerS tower = GetNode<TowerS>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(90))
{
	 tower.damageAmount += 1;
}}
private void Pirateship_damage_up()
{
	PirateShip tower = GetNode<PirateShip>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(90))
{
	 tower.damageAmount += 9;
}}
private void Bomber_damage_up()
{
	Bomber tower = GetNode<Bomber>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(90))
{
	 tower.damageAmount += 6;
}}
private void Cannon_damage_up()
{
	Cannon tower = GetNode<Cannon>("../..");

   	 if (tower == null)
	{
	  	  GD.Print("Tower path is wrong");
	  	  return;
	}
	if (GameManager.Instance != null && GameManager.Instance.SpendCoins(90))
{
	 tower.damageAmount += 15;
}}
	private void ShowUpgrade()
	{
		_upgrade.Show();
	}
	private void HideUpgrade()
	{
		_upgrade.Hide();
	}

	private void _on_blackbeard_upgrade_pressed() => ShowUpgrade();
	private void _on_bomber_upgrade_pressed() => ShowUpgrade();
	private void _on_cannon_upgrade_pressed() => ShowUpgrade();
	private void _on_pirateship_upgrade_pressed() => ShowUpgrade();
	private void _on_scalleywag_upgrade_pressed() => ShowUpgrade();
	
	private void _on_close_pressed() => HideUpgrade();
	
	//Range
	private void _on_blackbeard_range_pressed() => Blackbeard_Range_up();
	private void _on_bomber_range_pressed() => Bomber_Range_up();
	private void _on_cannon_range_pressed() => Cannon_Range_up();
	private void _on_pirateship_range_pressed() => Pirateship_Range_up();
	private void _on_scalleywag_range_pressed() => Scalleywag_Range_up();
	
	//Damage
	private void _on_blackbeard_damage_pressed() => Blackbeard_damage_up();
	private void _on_bomber_damage_pressed() => Bomber_damage_up();
	private void _on_cannon_damage_pressed() => Cannon_damage_up();
	private void _on_pirateship_damage_pressed() => Pirateship_damage_up();
	private void _on_scalleywag_damage_pressed() => Scalleywag_damage_up();
	
	//Fire Speed
	private void _on_blackbeard_fire_speed_pressed() => Blackbeard_fire_speed_up();
	private void _on_bomber_fire_speed_pressed() => Bomber_fire_speed_up();
	private void _on_cannon_fire_speed_pressed() => Cannon_fire_speed_up();
	private void _on_pirateship_fire_speed_pressed() => Pirateship_fire_speed_up();
	private void _on_scalleywag_fire_speed_pressed() => Scalleywag_fire_speed_up();
}
