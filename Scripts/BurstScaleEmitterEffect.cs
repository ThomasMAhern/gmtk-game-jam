using GMTKGJ2024.resources;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class BurstScaleEmitterEffect : Node
{

	[Export]
	public BurstScaleEffectStats Stats { get; set; }

	[Signal]
	public delegate void BurstScaleEffectEndedEventHandler();
	
	[Signal]
	public delegate void EmitScaleEffectEventHandler(float addPercent);
	
	private ulong? _effectEndTime = null;
	public void StartEffect()
	{
		_effectEndTime = Time.GetTicksMsec() + (ulong)(Stats.EffectTotalDurationSec * 1000);
		EmitSignal(SignalName.EmitScaleEffect, Stats.InitialBurstScaleAddPercent);
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_effectEndTime != null)
		{
			ulong timeTillEffectEnd =  (ulong)(_effectEndTime - Time.GetTicksMsec());
			if (timeTillEffectEnd > 0)
			{
				EmitSignal(SignalName.EmitScaleEffect, Stats.PerSecondScaleAddPercent * delta);
			}
			else
			{
				//emit one single last scale effect that matches what was left of the duration
				EmitSignal(SignalName.EmitScaleEffect, Stats.PerSecondScaleAddPercent * (delta + timeTillEffectEnd));
				EmitSignal(SignalName.BurstScaleEffectEnded);
			}
		}
	}
}