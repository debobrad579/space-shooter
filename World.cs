using Godot;
using System;

public partial class World : Node2D
{

	private int score = 0;

	public int Score
	{
		get { return score; }
		set
		{
			score = value;
			GetNode<Label>("ScoreLabel").Text = "Score: " + score.ToString();
		}
	}

	public async void _OnShipDestroyed()
	{
		await ToSignal(GetTree().CreateTimer(1.5), "timeout");
		new SaveAndLoad().SaveHighscore(Score);
		GetTree().ChangeSceneToFile("res://UI/GameOverScreen.tscn");
	}
}
