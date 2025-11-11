using Godot;
using System;

public partial class HealthComponent : Node
{
    [Signal]
    public delegate void HealthDepletedEventHandler();

    [Export]
    public int MaxHealth = 100;

    public int CurrentHealth;

    public override void _EnterTree()
    {
        base._EnterTree();
        CurrentHealth = MaxHealth;
    }


    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if(CurrentHealth <= 0)
        {
            EmitSignal(SignalName.HealthDepleted);
        }
    }
}
