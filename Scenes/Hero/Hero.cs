using Godot;
using System;

public partial class Hero : CharacterBody2D
{
    [Export]
    HealthComponent Health;

    [Export]
    NavigationAgent2D NavigationAgent;

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

        Vector2 PlannedVelocity = ToLocal(NavigationAgent.GetNextPathPosition()).Normalized() * 425f;
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
        CallDeferred("SetupMovement");
    }

    private void SetupMovement()
    {
        NavigationAgent.TargetPosition = GlobalPosition + GlobalPosition;
        NavigationAgent.VelocityComputed += OnVelocityComputed;
    }

    public override void _ExitTree()
    {
        Health.HealthDepleted -= Die;
        NavigationAgent.VelocityComputed -= OnVelocityComputed;
        base._ExitTree();
    }

    private void Die()
    {
        GlobalAutoload.Instance.Hero = null;
        QueueFree();
    }
}
