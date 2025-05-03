using Godot;
using System;
using ClassicRoguelikeCourse.managers.fsm.game_states;

public partial class ActionState : Node, IGameState
{
    public event Action Finished;
    private Player _player;

    public void Initialize()
    {
        _player = GetTree().CurrentScene.GetNode<Player>("%Player");
    }

    public void Run()
    {
        _player.Run();
        Finished?.Invoke();
    }
}