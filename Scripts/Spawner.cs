using Godot;
using System;

public partial class Spawner : Node
{
	// Path to the enemy scene containing multiple enemies
	private PackedScene _enemyScene;

	public override void _Ready()
	{
		// Load enemy host scene
		_enemyScene = (PackedScene)ResourceLoader.Load("res://scenes/Enemies.tscn");
		
		if (_enemyScene == null)
		{
			GD.PrintErr("Failed to load enemy scene at path: res://scenes/Enemies.tscn");
			return;
		}

		// Test spawn
		//SpawnEnemy("slime", new Vector2(100, 100));
	}

	// Spawn enemy on call
	public void SpawnEnemy(string enemyName, Vector2 position)
	{
		if (_enemyScene == null)
		{
			GD.PrintErr("Enemy scene is not loaded.");
			return;
		}

		// Instance the enemy container scene
		Node enemyContainerInstance = _enemyScene.Instantiate<Node>();
		
		if (enemyContainerInstance == null)
		{
			GD.PrintErr("Failed to instance the enemy scene.");
			return;
		}

		// Find the specific enemy by name
		CharacterBody2D specificEnemyTemplate = enemyContainerInstance.GetNodeOrNull<CharacterBody2D>(enemyName);
		
		if (specificEnemyTemplate != null)
		{
			// Instance the specific enemy directly
			CharacterBody2D enemyInstance = (CharacterBody2D)specificEnemyTemplate.Duplicate();
			
			// Set the position of the enemy
			enemyInstance.Position = position;
			
			// Add the enemy to the main scene
			AddChild(enemyInstance);
			GD.Print("tis here");
		}
		else
		{
			GD.PrintErr("Enemy not found: " + enemyName);
		}
	}
}
