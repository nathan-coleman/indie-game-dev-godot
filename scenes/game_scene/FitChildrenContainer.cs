using Godot;

namespace IndieGameDev.Game.UI;

public partial class FitChildrenContainer : Control
{
    public override void _Ready()
    {
        foreach (Node child in GetChildren())
        {
            if (child is not Control controlChild) continue;
            controlChild.Resized += RecalculateSize;
        }

        ChildEnteredTree += OnChildEnteredTree;
        ChildExitingTree += OnChildExitingTree;

        RecalculateSize();
    }

    private void OnChildEnteredTree(Node child)
    {
        if (child is not Control controlChild) return;
        controlChild.Resized += RecalculateSize;
        RecalculateSize();
    }

    private void OnChildExitingTree(Node child)
    {
        if (child is not Control controlChild) return;
        controlChild.Resized -= RecalculateSize;
        RecalculateSize();
    }

    private void RecalculateSize()
    {
        Vector2 newContainerSize = new();

        foreach (var child in GetChildren())
        {
            if (child is not Control controlChild) continue;

            Vector2 childDimensions = controlChild.Position + controlChild.Size;
            if (childDimensions.X > newContainerSize.X) newContainerSize.X = childDimensions.X;
            if (childDimensions.Y > newContainerSize.Y) newContainerSize.Y = childDimensions.Y;
        }

        CustomMinimumSize = newContainerSize;

        GD.Print($"Set minimum size to {newContainerSize}");
    }
}
