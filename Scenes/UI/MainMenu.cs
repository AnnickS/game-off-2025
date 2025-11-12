using Godot;
using System;

public partial class MainMenu : Control
{
	//ResourcePreloader("res://Scenes/Level/Level.tscn");

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
    }

	public void _on_exit_button_pressed()
    {
		GetTree().Quit();
    }
	
	public void LoadLevel(string path)
    {
		Show();

        if (ResourceLoader.HasCached(path))
        {
            
        }
        else
        {
			ResourceLoader.LoadThreadedRequest(path);
        }
    }
}
