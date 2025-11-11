using Godot;
using System;

public partial class HurtBox : Area2D
{
    [Export]
    public HealthComponent Health;

    public void ReceiveAttack(double damage)
    {
        Health.TakeDamage(damage);
    }
}
