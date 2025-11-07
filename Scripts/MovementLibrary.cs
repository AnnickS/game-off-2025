using Godot;
using System;

public partial class MovementLibrary : GodotObject
{

    public Vector2 MoveInStraightLine(Vector2 Mover, Vector2 Target)
    {
        Vector2 MoveUnitVector = Mover.DirectionTo(Target);
        return MoveUnitVector;
    }

    public Vector2 OrbitClockwiseAroundObject( Vector2 Target)
    {
        /*
        TODO: Implement
        */
        Vector2 MoveVector = new Vector2();

        return MoveVector;
    }
    
    public Vector2 OrbitCounterClockwiseAroundObject( Vector2 Target)
    {
        /*
        TODO: Implement
        */
        Vector2 MoveVector = new Vector2();

        return MoveVector;
    }
}
