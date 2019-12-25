using System;
using UnityEngine;

public class PauseController : SingletonMonoBehaviour<PauseController>
{
    public bool IsPaused
    {
        get => _isPaused;
        set
        {
            _isPaused = value;
            if (_isPaused)
            {
                Pause?.Invoke();
                Time.timeScale = 0;
            }
            else
            {
                Unpause?.Invoke();
                Time.timeScale = 1;
            }
        }
    }

    private bool _isPaused;

    public event Action Pause;
    public event Action Unpause;
}
