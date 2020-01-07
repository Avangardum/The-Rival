using System;

public struct Checkpoint
{
    public Action BacktrackingAction { get; }

    public Checkpoint(Action backtrackingAction)
    {
        BacktrackingAction = backtrackingAction;
    }
}
