using Godot;

namespace GMTKGJ2024.Scripts;

[Tool]
public partial class Circle2D : Node2D
{
	private float _radius;
	private Color _fill;

	[Export]
	public float Radius
	{
		get => _radius;
		set
		{
			_radius = value;
			QueueRedraw();
		}
	}

	[Export]
	public Color Fill
	{
		get => _fill;
		set
		{
			_fill = value;
			QueueRedraw();
		}
	}


	public override void _Draw()
	{
		DrawCircle(Vector2.Zero, Radius, Fill);
	}
}