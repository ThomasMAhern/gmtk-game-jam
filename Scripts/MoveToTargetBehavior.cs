using System;
using System.Numerics;
using GMTKGJ2024.resources;
using GMTKGJ2024.Scripts;
using Godot;
using Vector2 = Godot.Vector2;

namespace GMTKGJ2024.scenes;

public partial class MoveToTargetBehavior : Node
{

	[Export] public SlimeStats Stats;
	
	private CharacterBody2D _me;
	private Vector2 _targetPosition = Vector2.Inf;
	public override void _Ready()
	{
		_me = this.GetParentOfType<CharacterBody2D>();
	}
	
	private void OnTargetUpdate(Vector2 targetPosition)
	{
		_targetPosition = targetPosition;
	}
	public override void _PhysicsProcess(double delta)
	{
		if (_targetPosition != Vector2.Inf)
		{
			_me.SetVelocity((_targetPosition - _me.GlobalPosition).Normalized() * Stats.Speed);
			_me.MoveAndSlide();
		}
		else
		{
			_me.Velocity = Vector2.Zero;
		}
	}
}
