using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class ScaleAreaOfEffect : AreaOfEffectAbility
{

	[Export] private CollisionPolygon2D CollisionPolygon { get; set; }
	[Export] private Polygon2D VisualsPolygon { get; set; }
	[Export] private PulsingCircleEffect2D VisualsCircleEffect { get; set; }
	
	private List<Node2D> _sigilsForCleanup = new ();
	
	[Signal]
	public delegate void OnStartEffectEventHandler();
	
	public override void AddSigils(List<Node2D> sigils)
	{
		_sigilsForCleanup.AddRange(sigils);
		var calculatedAvgOrigin = _sigilsForCleanup.Aggregate(Vector2.Zero, ( runningSum, s2) => runningSum + s2.GlobalTransform.Origin) / _sigilsForCleanup.Count;
		var calculatedMaxAngleDistanceFromOrigin = _sigilsForCleanup.Aggregate(0f, ( runningMax, s2) => Math.Max(runningMax, (calculatedAvgOrigin - s2.GlobalTransform.Origin).Length()));
		GlobalPosition = calculatedAvgOrigin;
		
		CollisionPolygon.Polygon = _sigilsForCleanup.Select(s => s.GlobalTransform.Origin - calculatedAvgOrigin).ToArray();
		VisualsPolygon.Polygon = _sigilsForCleanup.Select(s => s.GlobalTransform.Origin - calculatedAvgOrigin).ToArray();
		VisualsCircleEffect.MaxRadius = calculatedMaxAngleDistanceFromOrigin;
	}

	public override void StartEffect()
	{
		EmitSignal(SignalName.OnStartEffect);
	}

	public void OnEffectEnd()
	{
		_sigilsForCleanup.ForEach(s => s.QueueFree());
		QueueFree();
	}
}