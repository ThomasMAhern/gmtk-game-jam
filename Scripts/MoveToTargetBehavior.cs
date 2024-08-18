using System;
using System.Numerics;
using GMTKGJ2024.resources;
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
		Node currentNode = this;
		while (currentNode != null)
		{
			if (currentNode is CharacterBody2D node)
			{
				_me = node;
				break;
			}

			currentNode = currentNode.GetParent();
		}

		if (_me == null)
		{
			throw new NullReferenceException("No parent CharacterBody2D found: Please attach this script to a descendant of CharacterBody2D!");
		}
	}
	
	private void OnTargetUpdate(Vector2 targetPosition)
	{
		_targetPosition = targetPosition;
	}
	public override void _PhysicsProcess(double delta)
	{
		if (_targetPosition != Vector2.Inf)
		{
			_me.Velocity = (_targetPosition - _me.Position).Normalized() * Stats.Speed;
			_me.MoveAndSlide();
		}
		else
		{
			_me.Velocity = Vector2.Zero;
		}
	}
}
