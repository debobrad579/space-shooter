using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	private PackedScene ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/Enemy.tscn");
	private PackedScene SHOOTING_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/ShootingEnemy.tscn");
	private PackedScene ZIGZAG_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/ZigzagEnemy.tscn");
	private PackedScene FISH_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/FishEnemy.tscn");
	private PackedScene FALLING_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/FallingEnemy.tscn");
	private PackedScene FLOOR_SHOOTER_ENEMY_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/FloorShooterEnemy.tscn");

	private Random random = new Random();
	private int enemyPercent = 30;
	private int shootingEnemyPercent = 25;
	private int fishEnemyPercent = 20;
	private int zigzagEnemyPercent = 15;
	private int fallingEnemyPercent = 5;


	private void _OnTimerTimeout()
	{
		int percent = random.Next(101);
		PackedScene enemyScene;
		Node2D spawnPoints = GetNode<Node2D>("RegularEnemySpawnPoints");

		if (percent < enemyPercent)
		{
			enemyScene = ENEMY_SCENE;
		}
		else if (percent < enemyPercent + shootingEnemyPercent)
		{
			enemyScene = SHOOTING_ENEMY_SCENE;
		}
		else if (percent < enemyPercent + shootingEnemyPercent + fishEnemyPercent)
		{
			enemyScene = FISH_ENEMY_SCENE;
			spawnPoints = GetNode<Node2D>("FishEnemySpawnPoints");
		}
		else if (percent < enemyPercent + shootingEnemyPercent + fishEnemyPercent + zigzagEnemyPercent)
		{
			enemyScene = ZIGZAG_ENEMY_SCENE;
			spawnPoints = GetNode<Node2D>("ZigzagEnemySpawnPoints");
		}
		else if (percent < enemyPercent + shootingEnemyPercent + fishEnemyPercent + zigzagEnemyPercent + fallingEnemyPercent)
		{
			enemyScene = FALLING_ENEMY_SCENE;
			spawnPoints = GetNode<Node2D>("FallingEnemySpawnPoints");
		}
		else
		{
			enemyScene = FLOOR_SHOOTER_ENEMY_SCENE;
			spawnPoints = GetNode<Node2D>("FloorShooterEnemySpawnPoints");
		}

		Area2D enemy = enemyScene.Instantiate() as Area2D;
		GetTree().CurrentScene.AddChild(enemy);
		enemy.Position = (spawnPoints.GetChildren()[random.Next(spawnPoints.GetChildCount())] as Marker2D).GlobalPosition;
	}
}
