using Godot;
using System;

public partial class Level : Node2D
{    
    PackedScene PackedGoon = GD.Load<PackedScene>("res://Scenes/Goon/Goon.tscn");
    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        if (@event is InputEventMouseButton eventMouseButton && !eventMouseButton.IsReleased())
        {
            Node2D NewGoon = PackedGoon.Instantiate<Node2D>();
            NewGoon.Position = eventMouseButton.Position;
            AddChild(NewGoon);
        }
    }
}