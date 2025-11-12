using Godot;
using System;

public partial class MainMenu : Control
{
	PackedScene StartScene = ResourceLoader.Load<PackedScene>("res://Scenes/Level/Level.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToPacked(StartScene);
    }

	public void _on_exit_button_pressed()
    {
		GetTree().Quit();
    }
}
