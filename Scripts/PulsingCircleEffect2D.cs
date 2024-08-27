using System;
using Godot;

namespace GMTKGJ2024.Scripts;

[Tool]
public partial class PulsingCircleEffect2D : Node2D
{
	private float _maxRadius;
	private Color _fillColorA;
	private Color _fillColorB;
	private Color _fillColorC;
	private float _animationProgress;
	private float _circleADelta = 0f;
	private float _circleBDelta = 1/3f;
	private float _circleCDelta = 2/3f;

	[Export]
	public float MaxRadius
	{
		get => _maxRadius;
		set
		{
			_maxRadius = value;
			QueueRedraw();
		}
	}

	[Export]
	public Color FillColorA
	{
		get => _fillColorA;
		set
		{
			_fillColorA = value;
			QueueRedraw();
		}
	}

	[Export]
	public Color FillColorB
	{
		get => _fillColorB;
		set
		{
			_fillColorB = value;
			QueueRedraw();
		}
	}

	
	[Export]
	public Color FillColorC
	{
		get => _fillColorC;
		set
		{
			_fillColorC = value;
			QueueRedraw();
		}
	}

	[Export]
	public float AnimationProgress
	{
		get => _animationProgress;
		set
		{
			_animationProgress = value;
			QueueRedraw();
		}
	}

	[Export]
	public float CircleBDelta
	{
		get => _circleBDelta;
		set
		{
			_circleBDelta = value;
			QueueRedraw();
		}
	}
	
	[Export]
	public float CircleCDelta
	{
		get => _circleCDelta;
		set
		{
			_circleCDelta = value;
			QueueRedraw();
		}
	}
	
	[Export]
	public float CircleADelta
	{
		get => _circleADelta;
		set
		{
			_circleADelta = value;
			QueueRedraw();
		}
	}


	public override void _Draw()
	{
		//use some simple math to make the value of each of those circle between 0 and 1
		var circleCurrAnimProgressA = AnimationProgress + _circleADelta - (int) Math.Floor(AnimationProgress + _circleADelta);
		var circleCurrAnimProgressB = AnimationProgress + _circleBDelta - (int) Math.Floor(AnimationProgress + _circleBDelta);
		var circleCurrAnimProgressC = AnimationProgress + _circleCDelta - (int) Math.Floor(AnimationProgress + _circleCDelta);

		if (circleCurrAnimProgressA > circleCurrAnimProgressB && circleCurrAnimProgressA < circleCurrAnimProgressC)
		{
			DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressA, FillColorA);
			if (circleCurrAnimProgressB > circleCurrAnimProgressC)
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressB, FillColorB);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressC, FillColorC);
			}
			else
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressC, FillColorC);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressB, FillColorB);
			}
		}else if (circleCurrAnimProgressB < circleCurrAnimProgressA && circleCurrAnimProgressB > circleCurrAnimProgressC)
		{
			DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressB, FillColorB);
			if (circleCurrAnimProgressA > circleCurrAnimProgressC)
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressA, FillColorA);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressC, FillColorC);
			}
			else
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressC, FillColorC);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressA, FillColorA);
			}
		}
		else
		{
			DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressC, FillColorC);
			if (circleCurrAnimProgressA > circleCurrAnimProgressB)
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressA, FillColorA);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressB, FillColorB);
			}
			else
			{
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressB, FillColorB);
				DrawCircle(Vector2.Zero, MaxRadius * circleCurrAnimProgressA, FillColorA);
			}
		}
		
	}
}