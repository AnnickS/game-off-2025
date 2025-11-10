using Godot;
using System;

public partial class GlobalAutoload : Node
{
    public static GlobalAutoload Instance { get; private set; }

    public Node Hero { get; set; }

    public override void _Ready()
    {
        Instance = this;
    }

}
