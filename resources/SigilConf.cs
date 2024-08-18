using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace GMTKGJ2024.resources;

[GlobalClass]
public partial class SigilConf : Resource
{
    [Export] public Array<PackedScene> SigilInventory { get; set; } = new();
    [Export] public int SigilCountForFullSpell { get; set; } = 0;

    public SigilConf() { }

    public SigilConf(Array<PackedScene> sigilInventory, int sigilCountForFullSpell)
    {
        SigilInventory = sigilInventory;
        SigilCountForFullSpell = sigilCountForFullSpell;
    }
}