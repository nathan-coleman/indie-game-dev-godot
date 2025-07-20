using System.Collections.Generic;
using Godot;

namespace IndieGameDev.Game.UI;

public partial class BubblesBox : Control
{
    [Export] private PackedScene bubbleBarItemPrefab;

    private static readonly Dictionary<string, int> demoBubbleValues = new()
    {
        { "Story", 10 },
        { "Backend", 20 },
        { "Gameplay", 40 },
        { "Sound", 80 },
        { "Progression", 50 },
        { "Hype", 70 },
        { "Polish", 30 }
    };

    public override void _Ready()
    {
        base._Ready();

        var bubbleBarContainer = GetNode("%BubbleBarContainer");

        foreach (Node childNode in bubbleBarContainer.GetChildren())
        {
            childNode.QueueFree();
        }

        foreach (var bubbleValue in demoBubbleValues)
        {
            var newBubbleBarItem = bubbleBarItemPrefab.Instantiate() as BubbleBarItem;

            newBubbleBarItem.BubbleName = bubbleValue.Key;
            newBubbleBarItem.BubbleAmount = bubbleValue.Value;

            bubbleBarContainer.AddChild(newBubbleBarItem);
        }
    }
}
