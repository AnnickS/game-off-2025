using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class Controller : Node
{
    [Export]
    public Character CharacterOwner { get; private set; }
    [Export]
    State InitialState;
    State CurrentState;
    [Export]
    Godot.Collections.Dictionary<String, State> States;

    public override void _Ready()
    {
        CharacterOwner = GetParent<Character>();

        foreach(Node Child in this.GetChildren())
        {
            if(Child is State)
            {
                State ChildState = (State)Child;
                ChildState.StateController = this;
                States[ChildState.Name.ToString().ToLower()] = ChildState;
            }
        }

        if (InitialState != null)
        {
            ChangeState(InitialState.Name.ToString().ToLower());
        }
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if (CurrentState != null)
        {
            CurrentState.Process(delta);
        }
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (CurrentState != null)
        {
            CurrentState.PhysicsProcess(delta);
        }
        base._PhysicsProcess(delta);
    }

    public override void _Input(InputEvent @event)
    {
        if (CurrentState != null)
        {
            CurrentState.Input(@event);
        }
        base._Input(@event);
    }

    public void ChangeState(String NewStateName)
    {
        if (CurrentState != null)
        {
            CurrentState.Exit();
        }
        
        CurrentState = States[NewStateName.ToLower()];

        if(CurrentState != null)
        {
            CurrentState.Enter();
        }

        return;
    }

}
