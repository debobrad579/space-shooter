using Godot;
using System;

public partial class GameOverScreen : ColorRect
{
	public override void _Ready()
	{
		GetNode<Label>("ScoreLabel").Text =
			"Score: " + new SaveAndLoad().LoadScore().ToString() + "\n" +
			"Highscore: " + new SaveAndLoad().LoadHighscore().ToString();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
		{
			GetTree().ChangeSceneToFile("res://UI/StartMenu.tscn");
		}
	}
}
