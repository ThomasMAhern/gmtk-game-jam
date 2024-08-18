using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using GMTKGJ2024.resources;
using GMTKGJ2024.Scripts;

public partial class AbilityPlaceSigil : Marker2D
{
	[Export] public SigilConf SigilConfig { get; set; }

	private List<Node2D> _placedSigils = new();
	private List<int> _usnusedInidices = new();
	private Random _rnd = new();
	private CharacterBody2D _character;

	private void PlaceRandomSigil()
	{
		var randomIndex = _rnd.Next(_usnusedInidices.Count - 1);
		var nextIndex = _usnusedInidices[randomIndex];
		_usnusedInidices.RemoveAt(randomIndex);
		
		var sigilBlueprint = SigilConfig.SigilInventory[nextIndex];
		var sigil = sigilBlueprint.Instantiate<Node2D>();
		
		_character.Owner.AddChild(sigil);
		sigil.GlobalTransform = GlobalTransform;
		sigil.GlobalRotationDegrees = _rnd.Next(360);
		_placedSigils.Add(sigil);

		if (_placedSigils.Count >= SigilConfig.SigilCountForFullSpell)
		{
			//Cast spell
			Reset();
		}
	}

	private void Reset()
	{
		_usnusedInidices.Clear();
		_usnusedInidices.AddRange(Enumerable.Range(0, SigilConfig.SigilInventory.Count));
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
