using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export]
    public double MaxHealth = 100.0;

    public double CurrentHealth;

    public override void _EnterTree()
    {
        base._EnterTree();
        CurrentHealth = MaxHealth;
    }


    public void TakeDamage(double damageAmount)
    {
        CurrentHealth -= damageAmount;
    }
}
