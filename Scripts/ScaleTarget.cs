using System;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class ScaleTarget : Area2D
{
	[Export] public float MaxScale { get; set; }
	
	[Signal] public delegate void OnScaleUpdatedEventHandler(float oldScale, float newScale);
	private float CurrentScale { get; set; } = 1;
	
	public void OnScaleChange(float addPercent)
	{
		var oldScale = CurrentScale;
		CurrentScale = Math.Clamp(CurrentScale + addPercent, 0, MaxScale);
		if (Math.Abs(oldScale - CurrentScale) > float.Epsilon)
		{
			EmitSignal(SignalName.OnScaleUpdated, oldScale ,CurrentScale);
		}
	}
}