using Godot;
using System;

public partial class AttackComponent : Area2D
{
    [Export]
    public int damage;

    [Signal]
    public delegate void HitHurtboxEventHandler();

    public override void _Ready()
    {
        base._Ready();
        this.AreaEntered += HandleAreaEntered;
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        this.AreaEntered -= HandleAreaEntered;
    }

    private void HandleAreaEntered(Area2D areaEntered)
    {
        if(areaEntered is HurtBox)
        {
            ((HurtBox)areaEntered).ReceiveAttack(damage);
            EmitSignal(SignalName.HitHurtbox);
        }
    }
}
