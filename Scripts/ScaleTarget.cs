using Godot;
using System;

public partial class ScaleEffect : Node
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
