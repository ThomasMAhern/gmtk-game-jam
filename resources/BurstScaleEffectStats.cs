using Godot;

namespace GMTKGJ2024.resources;

[GlobalClass]
public partial class BurstScaleEffectStats : Resource
{
    [Export]
    public float InitialBurstScaleAddPercent { get; set; }

    [Export]
    public float PerSecondScaleAddPercent { get; set; }
		
    [Export]
    public int EffectTotalDurationSec { get; set; }

    public BurstScaleEffectStats() : this(0, 0, 0) {}

    public BurstScaleEffectStats(float initialBurstScaleAddPercent, float perSecondScaleAddPercent, int effectTotalDurationSec)
    {
        InitialBurstScaleAddPercent = initialBurstScaleAddPercent;
        PerSecondScaleAddPercent = perSecondScaleAddPercent;
        EffectTotalDurationSec = effectTotalDurationSec;
    }
}