using Godot;

namespace GMTKGJ2024.Scripts;

public abstract partial class MomentumArea2D: Area2D
{
    public abstract Vector2 Momentum { get; }
}