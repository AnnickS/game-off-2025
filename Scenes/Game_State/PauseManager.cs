using Godot;
using System;

public partial class PauseManager : Node
{
    public static PauseManager Instance { get; private set; }
    [Signal]
    public delegate void GamePauseToggleEventHandler(bool isPaused);

    private bool isPaused = false;

    public override void _Ready()
    {
        Instance = this;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("Pause_Game"))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        GD.Print("blah");
        isPaused = !isPaused;

        EmitSignal(SignalName.GamePauseToggle, isPaused);
        GetTree().Paused = isPaused;
    }
}
