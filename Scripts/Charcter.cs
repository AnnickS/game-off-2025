using Godot;
using System;

public partial class Character : Node
{
    [Export]
    public float Speed { get; private set; }
    [Export]
    public Vector2 Target { get; private set; }
    [Export]
    Controller CharacterController;
    [Export]
    public AttackComponent CurrentAttack { get; private set; }
}
