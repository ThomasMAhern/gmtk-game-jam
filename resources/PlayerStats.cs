using Godot;

namespace GMTKGJ2024.resources;
[GlobalClass]
public partial class PlayerStats : Resource
{
    [Export]
    public float Speed { get; set; }

    public PlayerStats() : this(0) { }

    public PlayerStats(float speed)
    {
        Speed = speed;
    }
}