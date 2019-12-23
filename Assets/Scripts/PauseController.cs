using System;

public class PauseController : SingletonMonoBehaviour<PauseController>
{
    public bool IsPaused
    {
        get => _isPaused;
        set
        {
            _isPaused = value;
            if (_isPaused)
                Pause?.Invoke();
            else
                Unpause?.Invoke();
        }
    }

    private bool _isPaused;

    public event Action Pause;
    public event Action Unpause;
}
