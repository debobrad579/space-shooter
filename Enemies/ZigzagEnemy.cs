using Godot;
using System;

public partial class ZigzagEnemy : Enemy
{
	public override void _Ready()
	{
		horizontalSpeed = new Random().Next(100, 150);
		verticalSpeed = 25 * (new Random().Next(2) * 2 - 1);
		scoreIncrease = 7;
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		Vector2 newPosition = Position;
		newPosition.Y += (float)(verticalSpeed * delta);
		Position = newPosition;
	}

	private void _OnTimerTimeout()
	{
		verticalSpeed *= -1;
	}
}
