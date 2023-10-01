using Godot;
using System;

public partial class Laser : Area2D
{
	public int speed = 200;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 newPosition = Position;
		newPosition.X += (float)(speed * delta);
		Position = newPosition;
	}

	private void _OnScreenExited()
	{
		QueueFree();
	}
}
