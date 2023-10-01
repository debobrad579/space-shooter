using Godot;
using System;

public partial class EffectCreator : Node2D
{
	[Export] PackedScene EFFECT_SCENE;

	public override void _ExitTree()
	{
		if (
			EFFECT_SCENE is PackedScene &
			GlobalPosition.X >= 0 & GlobalPosition.X <= 320
			& GlobalPosition.Y >= 0 & GlobalPosition.Y <= 180
		)
		{
			Node2D effect = EFFECT_SCENE.Instantiate() as Node2D;
			GetTree().CurrentScene.CallDeferred("add_child", effect);
			effect.GlobalPosition = GlobalPosition;
		}
	}
}
