using Godot;
using System;

public partial class ToggleVisibilityOnPause : Control
{
	[Export]
	bool visibleOnPause = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
		PauseManager.Instance.GamePauseToggle += ToggleVisibility;

		if (!visibleOnPause) return;

		Hide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ToggleVisibility(bool isPaused)
    {
        if(visibleOnPause == isPaused)
        {
			Show();
        }
        else
        {
			Hide();
        }
    }
}
