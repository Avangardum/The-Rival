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
                OnPause?.Invoke();
                Time.timeScale = 0;
            }
            else
            {
                OnUnpause?.Invoke();
                Time.timeScale = 1;
            }
        }
    }

    private bool _isPaused;

    public event Action OnPause;
    public event Action OnUnpause;

    public void Pause() => IsPaused = true;

    public void Unpause() => IsPaused = false;

    protected override void Awake()
    {
        base.Awake();
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Death += Pause;
    }
}
