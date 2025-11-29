using Godot;
using System;

public partial class Goon : CharacterBody2D
{
    [Export]
    private float Speed = 275f;

    [Export]
    private InstantDamageArea Attack;

    [Export]
    private NavigationAgent2D NavigationAgent;

    [Export]
    private Timer RecalulatePathTimer;

    public override void _Ready()
    {
        base._Ready();
        Attack.HitHurtbox += QueueFree;
        RecalulatePathTimer.Timeout += RecalculatePath;
        CallDeferred("SetMovementTarget");
    }

    private void SetMovementTarget()
    {
        NavigationAgent.TargetPosition = GlobalAutoload.Instance.Hero.GlobalPosition;
    }

    private void RecalculatePath()
    {
        if(GlobalAutoload.Instance.Hero is not null)
        {
            SetMovementTarget();
        }
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        Attack.HitHurtbox -= QueueFree;
        RecalulatePathTimer.Timeout -= RecalculatePath;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        if (NavigationAgent.IsNavigationFinished())
        {
            return;
        }

        Velocity = ToLocal(NavigationAgent.GetNextPathPosition()).Normalized() * Speed;

        MoveAndSlide();
    }
}
