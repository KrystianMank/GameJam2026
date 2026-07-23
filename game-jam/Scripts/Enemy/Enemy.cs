using Godot;

public partial class Enemy : CharacterBody2D
{
	[Export] public HealthComponent HealthComponent {get; set;}
	[Export] public HurtboxComponent HurtboxComponent {get; set;}
	[Export] public float Speed {get; set;} = 100f;
	[Export] public float JumpVelocity {get;set;} = -100f;
	public bool TouchingWall = false;
    // Called when the node enters the scene tree for the first time.

    public override void _Ready()
    {
		HurtboxComponent.HealthComponent = HealthComponent;
        HurtboxComponent.Death += Death;
    }

	public void Death()
	{
		QueueFree();
	}

	public void Initialize(int hp, float speed, float jumpVelocity, Vector2 startPosition)
	{
		HealthComponent.HP = hp;
		Speed = speed;
		JumpVelocity = jumpVelocity;
		Position = startPosition;
	}

}
