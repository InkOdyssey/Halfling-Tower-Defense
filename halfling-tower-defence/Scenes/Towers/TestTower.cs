using Godot;
using System;

public partial class TestTower : Tower
{
	public virtual void ApplyDamage()
	{
		var bodies = hitArea.GetOverlappingBodies();
		foreach (var body in bodies)
		{
			if (body is TestEnemy Enemy)
			{
				Enemy.ApplyDamage(5);
				return;
			}
			
		}
	}
}
