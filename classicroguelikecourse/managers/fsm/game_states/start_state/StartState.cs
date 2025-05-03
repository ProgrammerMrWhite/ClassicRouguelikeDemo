using Godot;
using System;
using ClassicRoguelikeCourse.managers.fsm.game_states;

/// <summary>
/// 状态循环启动时首次进入本状态,并在本状态中初始化状态机及模块外的所有其他entity和manager,在后续切换中不会再次进入
/// </summary>
public partial class StartState : Node, IGameState
{
    public event Action Finished;
    private Player _player;
    private InputHandler _inputHandler;

    public void Initialize()
    {
        GD.Print("初始化Entity和Manager");
        _inputHandler = GetTree().CurrentScene.GetNode<InputHandler>("%InputHandler");
        _inputHandler.Initialize();
        _player = GetTree().CurrentScene.GetNode<Player>("%Player");
        _player.Initialize();
    }

    public void Run()
    {
        Finished?.Invoke();
    }
}