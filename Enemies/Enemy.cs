using Godot;
using System;

public partial class Enemy : Area2D
{
	public int horizontalSpeed = new Random().Next(25, 76);
	public int verticalSpeed = 0;
	public int armor = 3;
	public int scoreIncrease = 3;

	public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2(
			Position.X - (float)(horizontalSpeed * delta),
			Position.Y + (float)(verticalSpeed * delta)
		);
	}

	private void _OnAreaEntered(Area2D area)
	{
		if (area.SceneFilePath != "res://Player/Laser.tscn") return;

		area.QueueFree();
		armor--;
		if (armor <= 0)
		{
			((World)GetTree().CurrentScene).Score += scoreIncrease;
			QueueFree();
		}
	}

	private void _OnScreenExited()
	{
		QueueFree();
	}
}
