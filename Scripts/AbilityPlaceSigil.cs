using System;
using System.Collections.Generic;
using System.Linq;
using GMTKGJ2024.resources;
using Godot;

namespace GMTKGJ2024.Scripts;

public partial class AbilityPlaceSigil : Marker2D
{
	[Export] public AoeAbilityConf AoeAbilityConfig { get; set; }

	private readonly List<Node2D> _placedSigils = new();
	private readonly List<int> _unusedIndices = new();
	private readonly Random _rnd = new();
	private CharacterBody2D _character;

	private void PlaceRandomSigil()
	{
		var randomIndex = _rnd.Next(_unusedIndices.Count - 1);
		var nextIndex = _unusedIndices[randomIndex];
		_unusedIndices.RemoveAt(randomIndex);
		
		var sigilBlueprint = AoeAbilityConfig.SigilInventory[nextIndex];
		var sigil = sigilBlueprint.Instantiate<Node2D>();
		
		_character.Owner.AddChild(sigil);
		sigil.GlobalTransform = GlobalTransform;
		sigil.GlobalRotationDegrees = _rnd.Next(360);
		_placedSigils.Add(sigil);

		if (_placedSigils.Count >= AoeAbilityConfig.SigilCountForFullSpell)
		{
			//Cast spell
			var effect = AoeAbilityConfig.Effect.Instantiate<AreaOfEffectAbility>();
			_character.Owner.AddChild(effect);
			effect.AddSigils(_placedSigils);
			effect.StartEffect();
			Reset();
		}
	}

	private void Reset()
	{
		_unusedIndices.Clear();
		_unusedIndices.AddRange(Enumerable.Range(0, AoeAbilityConfig.SigilInventory.Count));
		_placedSigils.Clear();
	}

	public override void _Ready()
	{
		_character = this.GetParentOfType<CharacterBody2D>();
		Reset();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_text_submit"))
		{
			PlaceRandomSigil();
		}
	}
}