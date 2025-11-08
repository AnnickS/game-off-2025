using Godot;
using System;

public partial class Idle_State : State
{
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Process(double delta)
    {
        //Play idle animation + (whatever else has to do)
        //All enemies/hero can be idle while the player is choosing the next wave?
        base.Process(delta);
    }
}
