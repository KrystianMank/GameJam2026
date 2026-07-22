using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	public bool TouchingWall = false;

    public override void _Process(double delta)
    {
    }


	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		if(Input.IsActionJustPressed("ui_accept") && TouchingWall)
		{
			velocity.Y += JumpVelocity;
			TouchingWall = false;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	public async void OnArea2DAreaEntered(Area2D area)
	{
		if(area.GetParent() is StaticBody2D)
		{
			TouchingWall = true;
			var velo = Velocity;
			var touchPosition = Position;

			//Set(CharacterBody2D.PropertyName.Velocity, Vector2.Zero);
			
			// SetPhysicsProcess(false);

			// await ToSignal(GetTree().CreateTimer(1d), Timer.SignalName.Timeout);

			// SetPhysicsProcess(true);
		}
	}
}
