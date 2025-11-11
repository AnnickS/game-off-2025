using Godot;
using System;

public partial class Goon : Node2D
{
    [Export]
    private float Speed = 400f;

    [Export]
    private AttackComponent Attack;

    public override void _Ready()
    {
        base._Ready();
        Attack.HitHurtbox += QueueFree;
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        Attack.HitHurtbox -= QueueFree;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Position += Position.DirectionTo(GlobalAutoload.Instance.Hero.Position) * Speed * (float)delta;
    }
}
