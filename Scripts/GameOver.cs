using Godot;
using System;

public partial class GameOver : Control
{
	private Button Replay;
	private Button MainMenu;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Replay = GetNode<Button>("HBoxContainer/Replay");
		MainMenu = GetNode<Button>("GHBoxContainer/MainMenu");

		Replay.Pressed += OnReplayPressed;
		MainMenu.Pressed += OnMainMenuPressed;
	}

	private void OnReplayPressed()
	{
		GD.Print("replay pressed");
		GetTree().ChangeSceneToFile("res://scenes/game.tscn");
	}

	private void OnMainMenuPressed()
	{
		GD.Print("MainMenu pressed");
		GetTree().ChangeSceneToFile("res://scenes/Start.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
