using Godot;
using System;

public partial class HealthComponent : Node
{
    [Signal]
    public delegate void HealthDepletedEventHandler();

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
        
        if(CurrentHealth <= 0.0)
        {
            EmitSignal(SignalName.HealthDepleted);
        }
    }
}
