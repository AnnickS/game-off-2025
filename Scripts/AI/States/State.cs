using Godot;
using System;

public partial class State : Node
{

    /* add ref to controller */
    public Controller StateController { get; set; }

    public virtual void Enter()
    {
        return;
    }

    public virtual void Exit()
    {
        return;
    }

    public virtual void Process(double delta)
    {
        return;
    }

    public virtual void PhysicsProcess(double delta)
    {
        return;
    }

    public virtual void Input(InputEvent @event)
    {
    }
}
