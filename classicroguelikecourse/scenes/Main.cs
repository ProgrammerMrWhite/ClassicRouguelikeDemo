using Godot;
using System;

public partial class Main : Node
{
    private Fsm _fsm;

    public override void _Ready()
    {
        _fsm = GetNode<Fsm>("%Fsm");

        _fsm.Initialize();
    }

    public override void _Process(double delta)
    {
        _fsm.Run();
    }
}