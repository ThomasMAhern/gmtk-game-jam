using Godot;
using System;

public partial class StartPage : Control
{
	private Button start;
	private Button settings;
	private Button quit;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		start = GetNode<Button>("VBoxContainer/Start");
		settings = GetNode<Button>("VBoxContainer/Settings");
		quit = GetNode<Button>("VBoxContainer/Quit");

		start.Pressed += OnStartPressed;
		settings.Pressed += OnSettingsPressed;
		quit.Pressed += OnQuitPressed;
	}

	private void OnStartPressed()
	{
		GD.Print("start pressed");
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}

	private void OnSettingsPressed()
	{
		GD.Print("settings pressed");
		GetTree().ChangeSceneToFile("res://scenes/Settings.tscn");
	}

	private void OnQuitPressed()
	{
		GD.Print("QUIT PRESSED");
		GetTree().Quit();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
