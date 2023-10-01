using Godot;
using System;

public partial class FishEnemy : Enemy
{
	public Vector2 velocity = new Vector2(0, 0);
	public bool animationPlayed = false;

	public override void _Ready()
	{
		horizontalSpeed = new Random().Next(50, 101);
		verticalSpeed = new Random().Next(150, 226);
		armor = 2;
		scoreIncrease = 7;
		velocity.X = horizontalSpeed;
		velocity.Y = verticalSpeed;
	}

	public override void _PhysicsProcess(double delta)
	{
		velocity.Y -= (float)((verticalSpeed - 75) * delta);
		Vector2 newPosition = Position;
		newPosition.X -= (float)(velocity.X * delta);
		newPosition.Y -= (float)(velocity.Y * delta);
		if (newPosition.Y > Position.Y & !animationPlayed)
		{
			GetNode<AnimationPlayer>("AnimationPlayer").Play("Falling");
			animationPlayed = true;
		}
		Position = newPosition;
	}
}
