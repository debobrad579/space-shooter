using Godot;
using System;

public partial class HitEffect : Node2D
{
	private void _OnTimerTimeout()
	{
		QueueFree();
	}
}
