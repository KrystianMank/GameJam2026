using Godot;
using System;

public partial class Projectile : CharacterBody2D
{
	[Export] public float Speed {get; set;} = 500f;
	private Vector2 _direction = Vector2.Right;
    // Called when the node enters the scene tree for the first time.
    public override void _PhysicsProcess(double delta)
    {
        Velocity = Vector2.Right * Speed;
		MoveAndSlide();
    }

}
