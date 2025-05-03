using Godot;
using System;
using ClassicRoguelikeCourse.managers.fsm.game_states;

public partial class WaitForInputState : Node, IGameState
{
    public event Action Finished;

    public void Initialize()
    {
    }

    public void Run()
    {
        if (Input.IsAnythingPressed())
        {
            GD.Print("检测到按键输入");
            Finished?.Invoke();
        }
    }
}