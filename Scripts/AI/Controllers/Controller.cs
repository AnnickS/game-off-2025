using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class Controller : Node
{
    [ExportAttribute]
    State Initial_State;
    State Current_State;
    [Export]
    Godot.Collections.Array<State> States;

    public void Ready()
    {
        Current_State = Initial_State;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
    }

    public void Change_State(String New_State_Name)
    {
        return;
    }

}
