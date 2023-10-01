using Godot;
using System;

public partial class FallingEnemy : Enemy
{
	public int shootDirection = new Random().Next(2) * 2 - 1;

	private PackedScene BULLET_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/FallingEnemyBullet.tscn");

	public override void _Ready()
	{
		horizontalSpeed = 0;
		verticalSpeed = new Random().Next(10, 20);
		armor = 10;
		scoreIncrease = 10;
	}

	private void _OnTimerTimeout()
	{
		EnemyBullet bullet = BULLET_SCENE.Instantiate() as EnemyBullet;
		GetTree().CurrentScene.AddChild(bullet);
		bullet.Position = Position;
		if (shootDirection == -1) bullet.speed *= -1;
		shootDirection *= -1;
	}
}
