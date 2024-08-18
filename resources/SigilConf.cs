using System.Collections.Generic;
using Godot;
using Godot.Collections;

namespace GMTKGJ2024.resources;

[GlobalClass]
public partial class SigilConf : Resource
{
    [Export] public Array<PackedScene> SigilInventory { get; set; } = new();

    public SigilConf() { }

    public SigilConf(Array<PackedScene> sigilInventory)
    {
        SigilInventory = sigilInventory;
    }
}