using Godot;
using System;

public partial class Hero : Node2D
{
    public override void _EnterTree()
    {
        base._EnterTree();
        GlobalAutoload.Instance.Hero = this;
    }

    public override void _Ready()
    {
        base._Ready();
        GetHealthComponent().HealthDepleted += Die;
    }

    public override void _ExitTree()
    {
        GetHealthComponent().HealthDepleted -= Die;
        base._ExitTree();
    }

    private void Die()
    {
        QueueFree();
    }

    private HealthComponent GetHealthComponent()
    {
        return GetNode<HealthComponent>("HealthComponent");
    }
}
