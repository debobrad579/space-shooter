using Godot;
using System;

public partial class FloorShooterEnemy : Enemy
{
	public int lifespan = new Random().Next(20, 41);

	private PackedScene BULLET_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/FloorShooterEnemyBullet.tscn");

	public override void _Ready()
	{
		horizontalSpeed = 0;
		verticalSpeed = 0;
		armor = 15;
		scoreIncrease = 15;
		GetNode<Timer>("LifetimeTimer").WaitTime = lifespan;
	}

	private void _OnShootTimerTimeout()
	{
		EnemyBullet bullet = BULLET_SCENE.Instantiate() as EnemyBullet;
		GetTree().CurrentScene.AddChild(bullet);
		bullet.Position = GlobalPosition;
	}

	private void _OnLifetimeTimerTimeout()
	{
		GetNode<AnimationPlayer>("AnimationPlayer").Play("Lower");
	}

	private void _OnAnimationFinished(string animation)
	{
		if (animation == "Lower")
		{
			Position = new Vector2(-20, -20);
		}
	}
}
