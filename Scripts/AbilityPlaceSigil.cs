using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using GMTKGJ2024.resources;

public partial class AbilityPlaceSigil : Marker2D
{
	[Export] public SigilConf SigilConfig { get; set; }

	private List<Node2D> _placedSigils = new();
	private List<int> _usnusedInidices = new();
	private Random _rnd = new();

	private void PlaceRandomSigil()
	{
		var randomIndex = _rnd.Next(_usnusedInidices.Count - 1);
		var nextIndex = _usnusedInidices[randomIndex];
		_usnusedInidices.RemoveAt(randomIndex);
		
		var sigilBlueprint = SigilConfig.SigilInventory[nextIndex];
		var sigil = sigilBlueprint.Instantiate<Node2D>();
		Owner.AddChild(sigil);
		sigil.GlobalTransform = GlobalTransform;
		sigil.Rotation = _rnd.Next(400);
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
		_usnusedInidices.AddRange(Enumerable.Range(0, SigilConfig.SigilInventory.Count - 1));
		_placedSigils.Clear();
	}
}
