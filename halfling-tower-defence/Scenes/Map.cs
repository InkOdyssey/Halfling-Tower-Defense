using Godot;
using System.Collections.Generic;

public partial class Map : Node2D
{
	private PackedScene towerScene = GD.Load<PackedScene>("res://Scenes/test_tower.tscn");
	private PackedScene ghostScene = GD.Load<PackedScene>("res://Scenes/test_tower_ghost.tscn");

	private Node2D towerPreview;
	private bool placingTower = false;

	// Optional: track already placed towers to avoid overlaps
	private List<Area2D> placedTowerHitboxes = new List<Area2D>();

	public override void _Process(double delta)
	{
		if (!placingTower || towerPreview == null)
			return;

		// Tower follows mouse
		Vector2 mousePos = GetGlobalMousePosition();
		towerPreview.GlobalPosition = mousePos;

		// Check collisions for valid placement
		bool valid = true;

		// If your ghost has a CollisionShape2D or Area2D
		if (towerPreview.GetNodeOrNull<Area2D>("hitbox") is Area2D ghostHitbox)
		{
			var overlapping = ghostHitbox.GetOverlappingAreas();
			if (overlapping.Count > 0)
				valid = false;
		}

		// Change ghost color based on validity
		if (towerPreview is Node2D t)
		{
			var sprite = t.GetNodeOrNull<Sprite2D>("Sprite2D");
			if (sprite != null)
				sprite.Modulate = valid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
		}

		// Place tower on click if valid
		if (Input.IsActionJustPressed("place_tower") && valid)
		{
			var tower = towerScene.Instantiate<Node2D>();
			tower.GlobalPosition = mousePos;
			AddChild(tower);

			// Keep track of its hitbox
			if (tower.GetNodeOrNull<Area2D>("hitbox") is Area2D towerHitbox)
				placedTowerHitboxes.Add(towerHitbox);

			// Remove ghost
			towerPreview.QueueFree();
			towerPreview = null;
			placingTower = false;
		}
	}

	// Call this when the player clicks a "Place Tower" button
	public void StartPlacingTower()
	{
		if (placingTower) return;

		placingTower = true;
		towerPreview = ghostScene.Instantiate<Node2D>();
		AddChild(towerPreview);
	}
}
