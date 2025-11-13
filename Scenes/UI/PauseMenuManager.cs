using Godot;
using System;

public partial class PauseMenuManager : Node
{
    public static PauseMenuManager Instance { get; private set; }

    PackedScene MainMenuScene = ResourceLoader.Load<PackedScene>("res://Scenes/UI/Main_Menu.tscn");

    public override void _Ready()
    {
        Instance = this;
    }

    public void _on_resume_button_pressed()
    {
        PauseManager.Instance.TogglePause();
    }

    public void _on_main_menu_button_pressed()
    {
        PauseManager.Instance.TogglePause();
        GetTree().ChangeSceneToPacked(MainMenuScene);
    }

    public void _on_exit_button_pressed()
    {
        GetTree().Quit();
    }
}
