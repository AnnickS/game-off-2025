using Godot;
using System;

public partial class GlobalAutoload : Node
{
    public static GlobalAutoload Instance { get; private set; }

    public Node2D Hero { get; set; }

    public override void _EnterTree()
    {
        Instance = this;
    }
}
