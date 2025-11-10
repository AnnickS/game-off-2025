using Godot;
using System;

public partial class Hero : Node2D
{
    public override void _EnterTree()
    {
        base._EnterTree();
        GlobalAutoload.Instance.Hero = this;
    }
}
