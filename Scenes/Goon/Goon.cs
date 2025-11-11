using Godot;
using System;

public partial class Goon : Node2D
{
    [Export]
    private float Speed = 400f;

    [Export]
    private AttackComponent Attack;

    [Export]
    private NavigationAgent2D NavigationAgent;

    public override void _Ready()
    {
        base._Ready();
        Attack.HitHurtbox += QueueFree;
        CallDeferred("SetupMovement");
    }

    private void SetupMovement()
    {
        NavigationAgent.TargetPosition = GlobalAutoload.Instance.Hero.GlobalPosition;
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        Attack.HitHurtbox -= QueueFree;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (NavigationAgent.IsNavigationFinished())
        {
            return;
        }

        Vector2 velocity = ToLocal(NavigationAgent.GetNextPathPosition()).Normalized() * Speed;
        Position += velocity * (float)delta;
    }
}
