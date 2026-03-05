using Godot;
using System;

public partial class MyTileMap : TileMap
{
	private TileMap _mapNode = default!;

	private bool _buildMode = false;
	private bool _buildValid = false;
	private Vector2 _buildLocation = Vector2.Zero;
	private string _buildType = string.Empty;

	public override void _Ready()
	{
		// FIX: reference this TileMap instead of searching for a child
		_mapNode = this;

		foreach (Node node in GetTree().GetNodesInGroup("build_buttons"))
		{
			if (node is Button button)
			{
				button.Pressed += () => InitiateBuildMode(button.Name);
			}
		}
	}

	public override void _Process(double delta)
	{
		if (_buildMode)
		{
			UpdateTowerPreview();
		}
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		if (_buildMode && @event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left && _buildValid)
			{
				GD.Print("Build tower at: ", _buildLocation);
				CancelBuildMode();
			}
			else if (mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Right)
			{
				CancelBuildMode();
			}
		}
	}

	private void InitiateBuildMode(string towerType)
	{
		_buildType = towerType + "T1";
		_buildMode = true;

		GetNode("UI").Call("set_tower_preview", _buildType, GetGlobalMousePosition());
	}

	private void UpdateTowerPreview()
	{
		Vector2 mousePosition = GetGlobalMousePosition();

		TileMap towerExclusion = _mapNode.GetNode<TileMap>("TowerExclusion");

		Vector2I currentTile = towerExclusion.LocalToMap(mousePosition);
		Vector2 tilePosition = towerExclusion.MapToLocal(currentTile);

		int cellSource = towerExclusion.GetCellSourceId(0, currentTile);

		if (cellSource == -1)
		{
			GetNode("UI").Call("update_tower_preview", tilePosition, "ad54ff3c");
			_buildValid = true;
			_buildLocation = tilePosition;
		}
		else
		{
			GetNode("UI").Call("update_tower_preview", tilePosition, "adff4545");
			_buildValid = false;
		}
	}

	private void CancelBuildMode()
	{
		_buildMode = false;
		_buildValid = false;
		GetNode("UI").Call("hide_tower_preview");
	}
}
