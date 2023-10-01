using Godot;
using System;

public partial class EnemyBullet : Laser
{
	public override void _Ready()
	{
		speed = -200;
	}
}
