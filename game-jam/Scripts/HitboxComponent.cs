using Godot;
using System;

public partial class HitboxComponent : Node
{
    [Export]
    public int Damage{get; set;} = 1;
}
