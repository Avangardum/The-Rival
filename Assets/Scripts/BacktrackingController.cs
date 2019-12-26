using System;
using UnityEngine;

public class BacktrackingController : SingletonMonoBehaviour<BacktrackingController>
{
    public Checkpoint ActiveCheckPoint
    {
        get => _activeCheckpoint;
        set
        {
            if (value.Index < _activeCheckpoint.Index)
                throw new Exception("Произведена попытка активации чекпоинта, чей индекс меньше текущего активного чекпоинта");
            else
            {
                _activeCheckpoint = value;
            }
        }
    }

    private Checkpoint _activeCheckpoint;

    private void Update()
    {
        if (Input.GetAxisRaw("Backtrack") == 1)
            Backtrack();
    }

    private void Backtrack() => ActiveCheckPoint.BacktrackingAction.Invoke();
}
