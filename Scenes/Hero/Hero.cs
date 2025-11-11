using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export]
    HealthComponent Health;

    [Export]
    NavigationAgent2D NavigationAgent;

    [Export]
    Timer RecalculatePathTimer;

    private Vector2 CenterOfMap;

    public override void _EnterTree()
    {
        base._EnterTree();
        GlobalAutoload.Instance.Hero = this;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (NavigationAgent.IsNavigationFinished())
        {
            return;
        }

        Vector2 PlannedVelocity = ToLocal(NavigationAgent.GetNextPathPosition()).Normalized() * 275f;
        NavigationAgent.Velocity = PlannedVelocity;
    }
    
    private void OnVelocityComputed(Vector2 safeVelocity)
    {
        Velocity = safeVelocity;
        MoveAndSlide();
    }


    public override void _Ready()
    {
        base._Ready();
        Health.HealthDepleted += Die;
        RecalculatePathTimer.Timeout += RecalculatePath;
        CenterOfMap = GlobalPosition;
        CallDeferred("SetupMovement");
    }
    
    private void RecalculatePath()
    {
        NavigationAgent.TargetPosition = CenterOfMap;
    }

    private void SetupMovement()
    {
        NavigationAgent.TargetPosition = CenterOfMap;
        NavigationAgent.VelocityComputed += OnVelocityComputed;
    }

    public override void _ExitTree()
    {
        Health.HealthDepleted -= Die;
        NavigationAgent.VelocityComputed -= OnVelocityComputed;
        RecalculatePathTimer.Timeout -= RecalculatePath;
        base._ExitTree();
    }

    private void Die()
    {
        GlobalAutoload.Instance.Hero = null;
        QueueFree();
    }
}
