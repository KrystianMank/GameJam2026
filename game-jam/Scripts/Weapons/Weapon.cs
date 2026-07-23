using Godot;
using System;

public partial class Weapon : Area2D
{
	[Export] public AnimationPlayer AnimationPlayer;
	[Export] public HitboxComponent HitboxComponent {get; set;}
	[Export] public float CooldownTime {get; set;} = 1f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed("attack"))
		{
            AnimationPlayer.Play("attack");
			FireWeapon();
		}
    }

	public async virtual void FireWeapon()
	{
		HitboxComponent.Active = true;

		await ToSignal(GetTree().CreateTimer(CooldownTime), Timer.SignalName.Timeout);

		Cooldown();
	}
	public virtual void Cooldown()
	{
		HitboxComponent.Active = false;
	}
}
