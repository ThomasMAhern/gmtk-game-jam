using System.Collections.Generic;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class ScaleEventEmmitter : Area2D
{

	private List<ScaleTarget> _scaleEffectTargets = new();

	public void ScaleAdd(float addPercent)
	{
		foreach (var t in _scaleEffectTargets)
		{
			t.OnScaleChange(addPercent);
		}
	}
	public void OnPotentialTargetEntered(Area2D t)
	{
		if (t is ScaleTarget scaleTarget)
		{
			_scaleEffectTargets.Remove(scaleTarget);
			_scaleEffectTargets.Add(scaleTarget);
		}
	}
	
	public void OnPotentialTargetExited(Area2D t)
	{
		if (t is ScaleTarget scaleTarget)
		{
			_scaleEffectTargets.Remove(scaleTarget);
		}
	}
}