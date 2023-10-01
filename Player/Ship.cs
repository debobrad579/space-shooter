using Godot;
using System;

public partial class Ship : Area2D
{
	[Export] private int speed = 100;
	[Signal] public delegate void ShipDestroyedEventHandler();

	private PackedScene LASER_SCENE = ResourceLoader.Load<PackedScene>("res://Player/Laser.tscn");

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = new Vector2(0, 0);

		if (Input.IsActionPressed("move_up"))
		{
			velocity.Y -= (float)(1);
		}
		if (Input.IsActionPressed("move_down"))
		{
			velocity.Y += (float)(1);
		}
		if (Input.IsActionPressed("move_left"))
		{
			velocity.X -= (float)(1);
		}
		if (Input.IsActionPressed("move_right"))
		{
			velocity.X += (float)(1);
		}
		if (Input.IsActionJustPressed("shoot"))
		{
			Area2D laser = LASER_SCENE.Instantiate() as Area2D;
			GetTree().CurrentScene.AddChild(laser);
			laser.Position = Position;
		}

		velocity = velocity.Normalized();

		Vector2 newPosition = Position + new Vector2(velocity.X * (float)(speed * delta), velocity.Y * (float)(speed * delta));

		if (newPosition.Y < 8) newPosition.Y = 8;
		if (newPosition.Y > 172) newPosition.Y = 172;
		if (newPosition.X < 8) newPosition.X = 8;
		if (newPosition.X > 312) newPosition.X = 312;

		Position = newPosition;
	}

	private void _OnAreaEntered(Area2D area)
	{
		if (area is Enemy | area is EnemyBullet)
		{
			QueueFree();
			area.QueueFree();
			EmitSignal(SignalName.ShipDestroyed);
		}

	}
}
