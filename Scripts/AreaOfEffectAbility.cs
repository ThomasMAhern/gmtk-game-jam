using System.Collections.Generic;
using Godot;

namespace GMTKGJ2024.Scripts;

public abstract partial class AreaOfEffectAbility:Node2D
{
    public abstract void AddSigils(List<Node2D> sigils);
    public abstract void StartEffect();
}