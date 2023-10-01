using Godot;
using System;

public partial class StartMenu : ColorRect
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept"))
		{
			GetTree().ChangeSceneToFile("res://World.tscn");
		}
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
	}
}
