using Godot;

namespace GMTKGJ2024.Scripts;

public partial class PlayerAnimation: AnimationTree
{
    private CharacterBody2D AnimatedCharacter { get; set; }
    public override void _Ready()
    {
        AnimatedCharacter = this.GetParentOfType<CharacterBody2D>();
    }



    public override void _Process(double delta)
    {
        
        Set("parameters/idle_walk/idle_walk/blend_position", AnimatedCharacter.GetRealVelocity().Length());

        if (AnimatedCharacter.GetRealVelocity().Length() > 0.1f)
        {
            Set("parameters/idle_walk/direction_left_right/blend_position", AnimatedCharacter.GetRealVelocity().X);
        }

        Set("parameters/conditions/is_dead", Input.IsPhysicalKeyPressed(Key.Space));
    }
}