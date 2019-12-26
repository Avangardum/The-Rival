using System;

public struct Checkpoint
{
    public Action BacktrackingAction { get; }
    public int Index { get; }

    public Checkpoint(int index, Action backtrackingAction)
    {
        Index = index;
        BacktrackingAction = backtrackingAction;
    }
}
