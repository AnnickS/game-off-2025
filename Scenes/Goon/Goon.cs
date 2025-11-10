using Godot;
using System;

public partial class Goon : Node2D
{
    private float Speed = 400F;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        Position += Position.DirectionTo(GlobalAutoload.Instance.Hero.Position) * Speed * (float)delta;
    }

}
