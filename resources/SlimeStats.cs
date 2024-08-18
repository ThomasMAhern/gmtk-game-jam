using Godot;

namespace GMTKGJ2024.resources
{
	[GlobalClass]
	public partial class SlimeStats : Resource
	{
		[Export]
		public int Health { get; set; }

		[Export]
		public float Speed { get; set; }

		public SlimeStats() : this(0, 0) {}

		public SlimeStats(int health, float speed)
		{
			Health = health;
			Speed = speed;
		}
	}
}
