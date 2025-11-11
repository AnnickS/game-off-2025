using Godot;
using System;

public partial class Hero : Node2D
{
    [Export]
    HealthComponent Health;

    public override void _EnterTree()
    {
        base._EnterTree();
        GlobalAutoload.Instance.Hero = this;
    }

    public override void _Ready()
    {
        base._Ready();
        Health.HealthDepleted += Die;
    }

    public override void _ExitTree()
    {
        Health.HealthDepleted -= Die;
        base._ExitTree();
    }

    private void Die()
    {
        GlobalAutoload.Instance.Hero = null;
        QueueFree();
    }
}
