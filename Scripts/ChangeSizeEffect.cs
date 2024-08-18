using Godot;

namespace GMTKGJ2024.Scripts;

public partial class ChangeSizeEffect : Node
{
	private CharacterBody2D Character { get; set; }
	public override void _Ready()
	{
		Character = this.GetParentOfType<CharacterBody2D>();
	}

	public void OnScaleChange(float oldScale, float newScale)
	{
		Character.GlobalScale = Vector2.One * newScale;
	}
}