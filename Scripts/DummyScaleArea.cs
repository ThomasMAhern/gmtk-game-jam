using Godot;
using System;
using GMTKGJ2024.Scripts;

public partial class DummyScaleArea : Node
{
	private bool _isRunning = false;
	[Export]
	public BurstScaleEmitterEffect EmitterEffect { get; set; }
	
	public void OnEffectEnd()
	{
		QueueFree();
	}
	
	public override void _Process(double delta)
	{
		if (!_isRunning)
		{
			if (Input.IsPhysicalKeyPressed(Key.Shift))
			{
				_isRunning = true;
				EmitterEffect.StartEffect();
			}
		}
		
	}
}
