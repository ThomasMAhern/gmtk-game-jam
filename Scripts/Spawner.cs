using Godot;
using System;

public class Spawner : Node2D
{
    // Path to the enemy scene containing multiple enemies
    private PackedScene _enemyScene;

    public override void _Ready()
    {
        // Load enemy host scene
        _enemyScene = (PackedScene)ResourceLoader.Load("res://Scenes/Enemies.tscn");
        
        if (_enemyScene == null)
        {
            GD.PrintErr("Failed to load enemy scene at path: res://Scenes/Enemies.tscn");
            return;
        }

        //Test spawn
        //SpawnEnemy("Mob1", new Vector2(100, 100));
    }

    // Spawn enemy on call
    public void SpawnEnemy(string enemyName, Vector2 position)
    {
        if (_enemyScene == null)
        {
            GD.PrintErr("Enemy scene is not loaded.");
            return;
        }

        // Instance the enemy scene
        Node enemyContainerInstance = _enemyScene.Instance();
        
        if (enemyContainerInstance == null)
        {
            GD.PrintErr("Failed to instance the enemy scene.");
            return;
        }

        // Get the root node directly, which is now "Enemies"
        Node enemiesNode = enemyContainerInstance;

        if (enemiesNode == null)
        {
            GD.PrintErr("Enemies node not found in the enemy scene.");
            return;
        }

        // Find the specific enemy by name
        RigidBody2D specificEnemy = enemiesNode.GetNodeOrNull<RigidBody2D>(enemyName);
        
        if (specificEnemy != null)
        {
            // Create an instance of the specific enemy
            RigidBody2D enemyInstance = (RigidBody2D)specificEnemy.Duplicate();
            
            // Set the position of the enemy
            enemyInstance.Position = position;
            
            // Add the enemy to the main scene
            AddChild(enemyInstance);
        }
        else
        {
            GD.PrintErr("Enemy not found: " + enemyName);
        }
    }
}
