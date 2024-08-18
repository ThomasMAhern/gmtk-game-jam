using GMTKGJ2024.resources;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class Player : CharacterBody2D
{
    [Export] public PlayerStats Stats { get; set; }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionPressed("ui_right"))
        {
              Velocity = Vector2.Right * Stats.Speed;
        } else if (Input.IsActionPressed("ui_down"))
        {
              Velocity = Vector2.Down * Stats.Speed;
        } else if (Input.IsActionPressed("ui_left"))
        {
              Velocity = Vector2.Left * Stats.Speed;
        } else if (Input.IsActionPressed("ui_up"))
        {
              Velocity = Vector2.Up * Stats.Speed;
        } else {
              Velocity = Vector2.Zero;
        }
        
        MoveAndSlide();
    }
}