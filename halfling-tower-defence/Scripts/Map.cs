using Godot;
using System.Collections.Generic;

public partial class Map : Node2D
{
	private PackedScene towerScene1 = GD.Load<PackedScene>("res://Scenes/Towers/scalleywag.tscn");
	private PackedScene ghostScene1 = GD.Load<PackedScene>("res://Scenes/Towers/scalleywag_ghost.tscn");
	private PackedScene towerScene2 = GD.Load<PackedScene>("res://Scenes/Towers/Blackbeard.tscn");
	private PackedScene ghostScene2 = GD.Load<PackedScene>("res://Scenes/Towers/Blackbeard_ghost.tscn");
	private PackedScene towerScene3 = GD.Load<PackedScene>("res://Scenes/Towers/cannon.tscn");
	private PackedScene ghostScene3 = GD.Load<PackedScene>("res://Scenes/Towers/cannon_ghost.tscn");
	private PackedScene towerScene4 = GD.Load<PackedScene>("res://Scenes/Towers/bomber.tscn");
	private PackedScene ghostScene4 = GD.Load<PackedScene>("res://Scenes/Towers/bomber_ghost.tscn");
	private PackedScene towerScene5 = GD.Load<PackedScene>("res://Scenes/Towers/pirate_ship.tscn");
	private PackedScene ghostScene5 = GD.Load<PackedScene>("res://Scenes/Towers/pirate_ship_ghost.tscn");
	
	
	private PackedScene placement = GD.Load<PackedScene>("res://Scenes/placement_area.tscn");
	
	private Node2D placementArea;
	private CharacterBody2D towerPreview;
	private CharacterBody2D towerPreview2;
	private CharacterBody2D towerPreview3;
	private CharacterBody2D towerPreview4;
	private CharacterBody2D towerPreview5;
	private bool placingTower = false;
	private int towernum;

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
		
		
		// checks if tower ghost is a Node2D and assigns it to variable "t"
		if (towerPreview is CharacterBody2D t)
		{
			var sprite = t.GetNodeOrNull<Sprite2D>("Sprite2D");
			
			// Change ghost color based on validity
			if (sprite != null)
				// the "valid ? ... : ..." is shorthand for "if valid(), else()"
				sprite.Modulate = valid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
		}

		// Places tower on click if valid
		if (Input.IsActionJustPressed("place_tower") && valid == true)
		{
			var tower = towerScene1.Instantiate<Tower>();
			switch (towernum)
			{
				case 1:
					tower = towerScene1.Instantiate<Tower>();
					break;
				case 2:
					tower = towerScene2.Instantiate<Tower>();
					break;
				case 3:
					tower = towerScene3.Instantiate<Tower>();
					break;
				case 4:
					tower = towerScene4.Instantiate<Tower>();
					break;
				case 5:
					tower = towerScene5.Instantiate<Tower>();
					break;
			}
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
	public void StartPlacingScalleywag()
	{
		if (placingTower) return;

		placingTower = true;
		towernum = 1;
		towerPreview = ghostScene1.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
	
	
	public void StartPlacingBlackbeard()
	{
		if (placingTower) return;

		placingTower = true;
		towernum = 2;
		towerPreview = ghostScene2.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
	
	
	public void StartPlacingCannon()
	{
		if (placingTower) return;

		placingTower = true;
		towernum = 3;
		towerPreview = ghostScene3.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
	
	
	public void StartPlacingBomber()
	{
		if (placingTower) return;

		placingTower = true;
		towernum = 4;
		towerPreview = ghostScene4.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
	
	public void StartPlacingPirate_Ship()
	{
		if (placingTower) return;

		placingTower = true;
		towernum = 5;
		towerPreview = ghostScene5.Instantiate<CharacterBody2D>();
		AddChild(towerPreview);
	}
}
