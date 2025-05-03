using ClassicRoguelikeCourse.managers.fsm.game_states;
using Godot;

public partial class Fsm : Node
{
    private IGameState _currentState;

    private StartState _startState;
    private WaitForInputState _waitForInputState;
    private ActionState _actionState;
    private CombatState _combatState;

    public void Initialize()
    {
        _startState = GetNode<StartState>("%StartState");
        _waitForInputState = GetNode<WaitForInputState>("%WaitForInputState");
        _actionState = GetNode<ActionState>("%ActionState");
        _combatState = GetNode<CombatState>("%CombatState");

        _startState.Finished += StartStateOnFinished;
        _waitForInputState.Finished += WaitForInputStateOnFinished;
        _actionState.Finished += ActionStateOnFinished;
        _combatState.Finished += CombatStateOnFinished;

        _startState.Initialize();
        _waitForInputState.Initialize();
        _actionState.Initialize();
        _combatState.Initialize();

        _currentState = _startState;
    }

    public void Run()
    {
        _currentState.Run();
    }

    private void CombatStateOnFinished()
    {
        _currentState = _waitForInputState;
        GD.Print("切换至waitForInputState");
    }

    private void ActionStateOnFinished()
    {
        _currentState = _combatState;
        GD.Print("切换至combatState");
    }

    private void WaitForInputStateOnFinished()
    {
        _currentState = _actionState;
        GD.Print("切换至actionState");
    }


    private void StartStateOnFinished()
    {
        _currentState = _waitForInputState;
        GD.Print("切换至waitForInputState");
    }
}