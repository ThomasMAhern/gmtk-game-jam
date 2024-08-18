using Godot;

namespace GMTKGJ2024.scenes;

public partial class TargetPlayerBehavior : Node
{
	private Node2D _targetedObject;
	private Vector2 _targetPosition = Vector2.Inf;
	
	[Signal]
	public delegate void OnNewTargetPositionEventHandler(Vector2 targetPosition);

	private void OnBodyEntered(Node2D b)
	{
		_targetedObject = b;
	}
	
	private void OnBodyExited(Node2D b)
	{
		if (_targetedObject == b)
		{
			_targetedObject = null;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_targetedObject != null)
		{	
			if (_targetPosition != _targetedObject.GlobalPosition)
			{
				_targetPosition = _targetedObject.GlobalPosition;
				EmitSignal(SignalName.OnNewTargetPosition, _targetPosition);
			}
		}
		else
		{
			if (_targetPosition != Vector2.Inf)
			{
				_targetPosition = Vector2.Inf;
				EmitSignal(SignalName.OnNewTargetPosition, _targetPosition);
			}
		}
	}
}
