using Godot;
using System;
using GMTKGJ2024.resources;

public partial class GetSlimeDetectionRadiusScale : Node2D
{
	[Export] private SlimeStats _stats;
	
	
	public override void _Ready()
	{
		Scale = Vector2.One * _stats.DetectionAreaScale;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
