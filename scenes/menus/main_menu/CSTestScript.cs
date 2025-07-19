using Godot;
using System;

namespace IndieGameDev.Nodes;

public partial class CSTestScript : Node
{
    public override void _Ready()
    {
        Console.WriteLine("CSTestScript getting ready");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Console.WriteLine("CSTestScript processing");
    }
}
