using Godot;
using System;

public partial class ControlUI : Control
{

	Control StickCircleContainer;
	Control StickButtonContainer;

	bool IsScreenPressed = false;
	Viewport GameViewport;

	public override void _Ready()
	{
		GameViewport = GetViewport();
		StickCircleContainer = GetNode<Control>("StickCircleContainer");
		StickButtonContainer = GetNode<Control>("StickButtonContainer");

		StickCircleContainer.Visible = false;
		StickButtonContainer.Visible = false;

	}

	public override void _Process(double delta)
	{
		Vector2 mousePosition = GameViewport.GetMousePosition();

		if (IsScreenPressed) {
			StickButtonContainer.Position = mousePosition;
		}

		if (Input.IsActionJustPressed("LeftClick")) {
			IsScreenPressed = true;

			StickButtonContainer.Position = mousePosition;
			StickCircleContainer.Position = mousePosition;
			
			StickButtonContainer.Visible = true;
			StickCircleContainer.Visible = true;
		}
		else if (Input.IsActionJustReleased("LeftClick")) {
			StickButtonContainer.Visible = false;
			StickCircleContainer.Visible = false;
		}
		
	}
}