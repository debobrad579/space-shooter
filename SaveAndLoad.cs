using Godot;
using System;

public partial class SaveAndLoad : Node
{
	public string SAVE_PATH = "user://save.cfg";

	public void SaveHighscore(int score)
	{
		ConfigFile config = new ConfigFile();
		config.SetValue("Score", "value", score);

		if (score > LoadHighscore())
		{
			config.SetValue("Highscore", "value", score);
		}
		else
		{
			config.SetValue("Highscore", "value", LoadHighscore());
		}

		config.Save(SAVE_PATH);
	}

	public int LoadHighscore()
	{
		ConfigFile config = new ConfigFile();
		if (config.Load(SAVE_PATH) != Error.Ok) { return 0; }
		return (int)config.GetValue("Highscore", "value", 0);
	}

	public int LoadScore()
	{
		ConfigFile config = new ConfigFile();
		if (config.Load(SAVE_PATH) != Error.Ok) { return 0; }
		return (int)config.GetValue("Score", "value", 0);
	}
}
