using Godot;
using System;

public partial class HurtboxComponent : Node
{
    [Signal] public delegate void DeathEventHandler();
    public HealthComponent HealthComponent;

    public void DealDamage(int damage)
    {
        HealthComponent.HP -= damage;
        if(HealthComponent.HP <= 0)
        {
            EmitSignal(SignalName.Death);
        }
    }
}
