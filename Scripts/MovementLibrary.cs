using Godot;
using System;

public partial class MovementLibrary : GodotObject
{

    public Vector2 MoveInStraightLine(Vector2 Mover, Vector2 Target)
    {
        Vector2 MoveUnitVector = new Vector2((Target.X - Mover.X), (Target.Y - Mover.Y));

        return MoveUnitVector;
    }

    public Vector2 MoveClockwiseToObject( Vector2 Target)
    {
        Vector2 MoveVector = new Vector2();

        return MoveVector;
    }
    
    public Vector2 MoveCounterClockwiseToObject( Vector2 Target)
    {
        Vector2 MoveVector = new Vector2();

        return MoveVector;
    }
}
