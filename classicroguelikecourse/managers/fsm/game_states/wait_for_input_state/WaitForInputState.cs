using Godot;
using System;
using ClassicRoguelikeCourse.managers.fsm.game_states;

public partial class WaitForInputState : Node, IGameState
{
    public event Action Finished;
    private InputHandler _inputHandler;

    public void Initialize()
    {
        _inputHandler = GetTree().CurrentScene.GetNode<InputHandler>("%InputHandler");
        _inputHandler.MovementInputHandled += InputHandlerOnMovementInputHandled;
    }

    private void InputHandlerOnMovementInputHandled(Vector2I _)
    {
        Finished?.Invoke();
    }

    public void Run()
    {
        _inputHandler.Run();
    }
}