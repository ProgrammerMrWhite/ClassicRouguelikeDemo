using Godot;
using System;
using ClassicRoguelikeCourse.managers;

public partial class InputHandler : Node, IManager
{
    public event Action<Vector2I> MovementInputHandled;
    private Timer _timer;

    private float _maxMovementInterval = 0.4f;
    private float _minMovementInterval = 0.1f;
    private float _currentMovementInterval;

    public void Initialize()
    {
        _timer = GetNode<Timer>("MovementTimer");
    }

    public void Run()
    {
        HandleMovementInput();
    }

    private bool HandleMovementInput()
    {
        var direction = GetDirection();
        if (direction == Vector2.Zero)
        {
            _currentMovementInterval = _maxMovementInterval;
            return false;
        }

        if (!_timer.IsStopped())
        {
            return false;
        }

        MovementInputHandled?.Invoke(direction);
        _timer.Start(_currentMovementInterval);
        _currentMovementInterval = _minMovementInterval;
        return true;
    }

    private Vector2I GetDirection()
    {
        var direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_UP, GameConstants.INPUT_MOVE_DOWN);
        if (direction.X != 0 && direction.Y != 0)
        {
            direction = Vector2.Zero;
        }

        return (Vector2I)direction.Sign();
    }
}