using System;

namespace ClassicRoguelikeCourse.managers.fsm.game_states;

public interface IGameState
{
    public event Action Finished;

    public void Initialize();

    public void Run();
}