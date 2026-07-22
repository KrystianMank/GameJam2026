using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	[Export]
	public PackedScene EnemyScene;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Enemy enemy = EnemyScene.Instantiate<Enemy>();
		enemy.Initialize(1, 100f, 100f, new Vector2(100, 100));
		AddChild(enemy);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
