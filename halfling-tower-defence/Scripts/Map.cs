using Godot;
using System.Collections.Generic;

public partial class Map : Node2D
{
	private PackedScene towerScene = GD.Load<PackedScene>("res://Scenes/test_tower.tscn");
	private PackedScene ghostScene = GD.Load<PackedScene>("res://Scenes/test_tower_ghost.tscn");
	private PackedScene placement = GD.Load<PackedScene>("res://Scenes/placement_area.tscn");
	
	private Node2D placementArea;
	private CharacterBody2D towerPreview;
	private bool placingTower = false;

	// creates list of Area2Ds of placed towers; empty for now
	private List<Area2D> placedTowerHitboxes = new List<Area2D>();
	
	
	public override void _Ready()
	{
		placementArea = GetNode<Node2D>("/root/map/placement_area");
		Area2D placementZone = placementArea.GetNode<Area2D>("placement");
		placedTowerHitboxes.Add(placementZone);
	}
	
	
	public override void _Process(double delta)
	{
		if (!placingTower || towerPreview == null)
			return;

		// Tower follows mouse
		Vector2 mousePos = GetGlobalMousePosition();
		towerPreview.GlobalPosition = mousePos;

		// Check collisions for valid placement
		bool valid = true;

		// Looks for an area2D named "hitbox" in towerpreview (ghost),
		// then checks if it is an Area2D and gives it variable name "ghostHitbox"
		if (towerPreview.GetNodeOrNull<Area2D>("hitbox") is Area2D ghostHitbox)
		{
			
			//creates placedHitbox as a temp variable for every value in list,
			//then checks if the ghost hitbox overlaps with each list value
			foreach (Area2D placedHitbox in placedTowerHitboxes)
			{
				if (ghostHitbox.OverlapsArea(placedHitbox))
				{
					valid = false;
					break;
				}
			}
		}
		
		
		// checks if tower ghost is a Node2D and assigns it variable "t"
		if (towerPreview is CharacterBody2D t)
		{
			var sprite = t.GetNodeOrNull<Sprite2D>("Sprite2D");
			
			// Change ghost color based on validity
			if (sprite != null)
				sprite.Modulate = valid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
		}

		// Places tower on click if valid
		if (Input.IsActionJustPressed("place_tower") && valid == true)
		{
			var tower = towerScene.Instantiate<CharacterBody2D>();
			tower.GlobalPosition = mousePos;
			AddChild(tower);

			//  assigns hitbox node as towerHitbox variable
			if (tower.GetNodeOrNull<Area2D>("hitbox") is Area2D towerHitbox)
			
				//adds hitbox of new tower to list of Area2Ds of placed towers
				placedTowerHitboxes.Add(towerHitbox);

			// Removes ghost and resets conditions
			towerPreview.QueueFree();
			towerPreview = null;
			placingTower = false;
		}
	}

	// Call this when the player clicks a "Place Tower" button
	public void StartPlacingTest_Tower()
	{
		if (placingTower) return;

		placingTower = true;
		towerPreview = ghostScene.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
}
