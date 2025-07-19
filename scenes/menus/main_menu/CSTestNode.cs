using Godot;
using System;

namespace IndieGameDev.Nodes;

public partial class CSTestNode : Node
{
    public override void _Ready()
    {
        Console.WriteLine("CSTestNode getting ready");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Console.WriteLine("CSTestNode processing");
    }
}
