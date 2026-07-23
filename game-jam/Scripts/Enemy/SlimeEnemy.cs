using Godot;

public partial class SlimeEnemy : Enemy
{
    private Vector2 _direction;
    public override void _Ready()
    {
        base._Ready();
       ChangeDirection();
    }
    public override void _PhysicsProcess(double delta)
    {
        if (!IsOnFloor())
		{
			Velocity += GetGravity() * (float)delta;
		}
        Velocity = _direction * Speed;
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
        if(area is Sword sword && sword.HitboxComponent.Active)
        {
            HurtboxComponent.DealDamage(sword.HitboxComponent.Damage);
        }
        if(area is Projectile projectile)
        {
            GD.Print("dd");
            HurtboxComponent.DealDamage(projectile.HitboxComponent.Damage);
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