using Godot;
using System;

public class Start : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Connect button to process
        GetNode<Button>("VBoxContainer/Start").Connect("pressed", this, nameof(OnStartPressed));
        GetNode<Button>("VBoxContainer/Settings").Connect("pressed", this, nameof(OnSettingsPressed));
        GetNode<Button>("VBoxContainer/Quit").Connect("pressed", this, nameof(OnQuitPressed));
    }

    private void OnStartPressed()
    {
        GD.Print("Start Pressed");
        GetTree().ChangeScene("res://Scenes/Game.tscn");
    }

    private void OnSettingsPressed() {
        GD.Print("Settings Pressed");
        GetTree().ChangeScene("res://Scenes/Settings.tscn");
    }

    private void OnQuitPressed() {
        GD.Print("Quit Pressed");
        GetTree().Quit();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
