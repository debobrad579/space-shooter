using Godot;
using System;

public partial class ShootingEnemy : Enemy
{
    public float shootTiming = new Random().Next(40, 101) / 25;

    private PackedScene BULLET_SCENE = ResourceLoader.Load<PackedScene>("res://Enemies/EnemyBullet.tscn");

    public override void _Ready()
    {
        horizontalSpeed = new Random().Next(30, 61);
        armor = 5;
        scoreIncrease = 5;
        GetNode<Timer>("Timer").WaitTime = shootTiming;
    }

    private void _OnTimerTimeout()
    {
        Area2D bullet = BULLET_SCENE.Instantiate() as Area2D;
        GetTree().CurrentScene.AddChild(bullet);
        bullet.Position = Position;
    }
}
