using Godot;
using System;
using ClassicRoguelikeCourse.managers.fsm.game_states;

public partial class CombatState : Node, IGameState
{
    public event Action Finished;

    public void Initialize()
    {
    }

    public void Run()
    {
        Finished?.Invoke();
    }
}