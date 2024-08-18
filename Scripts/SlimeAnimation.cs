using Godot;

namespace GMTKGJ2024.Scripts;

public partial class SlimeAnimation : AnimationTree
{
	
	[Export] private CharacterBody2D AnimatedCharacter { get; set; }
	

	public override void _Process(double delta)
	{
		Set("parameters/Idle_Walk/blend_position", AnimatedCharacter.GetRealVelocity().Length());
		
		Set("parameters/conditions/is_dead", Input.IsPhysicalKeyPressed(Key.Space));
	}
}