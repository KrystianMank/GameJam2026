using Godot;
using System;

public partial class Projectile : Area2D
{
    [Export] public HitboxComponent HitboxComponent;
	[Export] public float Speed {get; set;} = 500f;
	private Vector2 _direction = Vector2.Right;
    // Called when the node enters the scene tree for the first time.
    public override void _Process(double delta)
    {
        Position += Vector2.Right * Speed * (float)delta;
    }

}
