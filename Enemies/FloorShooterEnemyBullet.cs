using Godot;
using System;

public partial class FloorShooterEnemyBullet : EnemyBullet
{
	public override void _PhysicsProcess(double delta)
	{
		Vector2 newPosition = Position;
		newPosition.Y += (float)(speed * delta);
		Position = newPosition;
	}
}
