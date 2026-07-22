using Godot;

public partial class SlimeEnemyJumper : Enemy
{
    private Vector2 _direction;
    public override void _Ready()
    {
        base._Ready();
		JumpVelocity = -300f;
       ChangeDirection();
    }
    public override void _PhysicsProcess(double delta)
    {
		var velocity = Velocity;
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		if(IsOnFloor())
		{
			velocity.Y = -300f;
		}

        velocity = _direction * Speed;

		Velocity = velocity;
        MoveAndSlide();
    }

    public void OnArea2DAreaEntered(Area2D area)
    {
        if(area.GetParent() is StaticBody2D)
		{
			ReverseDirection();
        }
        if(area.GetParent() is Enemy)
        {
            GD.Print("wall");
            ReverseDirection();
        }
        if(area is Sword sword)
        {
            HurtboxComponent.DealDamage(sword.HitboxComponent.Damage);
        }
    }

    public void OnTimerTimeout()
    {
        ChangeDirection();
    }
    public void ReverseDirection()
    {
        if(_direction == Vector2.Left) _direction = Vector2.Right;
        if(_direction == Vector2.Right) _direction = Vector2.Left;
    }

    public void ChangeDirection()
    {
        var randomDir = GD.RandRange(0,1);
        switch (randomDir)
        {
            case 0:
                _direction = Vector2.Left;
                break;
            case 1:
                _direction = Vector2.Right;
                break;
        }
    }
}
