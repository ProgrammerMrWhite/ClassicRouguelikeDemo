using Godot;
using System;
using System.ComponentModel;

namespace ClassicRoguelikeCourse.components;

public partial class MovementComponents : Node, IComponent
{
    private InputHandler _inputHandler;
    private Node2D _parent;
    private Vector2 _movement;

    public void Initialize()
    {
        _inputHandler = GetTree().CurrentScene.GetNode<InputHandler>("%InputHandler");
        _inputHandler.MovementInputHandled += InputHandlerOnMovementInputHandled;

        _parent = GetOwner<Node2D>();
    }

    private void InputHandlerOnMovementInputHandled(Vector2I direction)
    {
        _movement = direction;
    }

    public void Run()
    {
        if (_movement == Vector2.Zero) return;
        _parent.GlobalPosition += _movement * new Vector2I(16, 16);
        _movement = Vector2.Zero;
    }
}