using System.Collections.Generic;
using GMTKGJ2024.Scripts;
using Godot;
using Godot.Collections;

namespace GMTKGJ2024.resources;

[GlobalClass]
public partial class AoeAbilityConf : Resource
{
    [Export] public Array<PackedScene> SigilInventory { get; set; } = new();
    [Export] public int SigilCountForFullSpell { get; set; } = 0;
    [Export] public PackedScene Effect { get; set; } = new();

    public AoeAbilityConf() { }

    public AoeAbilityConf(Array<PackedScene> sigilInventory, int sigilCountForFullSpell, PackedScene effect)
    {
        SigilInventory = sigilInventory;
        SigilCountForFullSpell = sigilCountForFullSpell;
        Effect = effect;
    }
}