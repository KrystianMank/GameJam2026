using Godot;
using System;

public partial class HitboxComponent : Node
{
    [Export]
    public int Damage{get; set;} = 1;
    public bool Active{get; set;} = false;
}
