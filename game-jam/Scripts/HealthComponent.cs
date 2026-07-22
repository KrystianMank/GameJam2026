using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export]
    public int HP{get; set;} = 1;
}
