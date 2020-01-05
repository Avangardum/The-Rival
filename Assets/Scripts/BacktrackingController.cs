using System;
using UnityEngine;

public class BacktrackingController : SingletonMonoBehaviour<BacktrackingController>
{
    [SerializeField] private NewSkillNotification _notification;

    private static bool _isNotificationShown = false;

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

    protected override void Awake()
    {
        base.Awake();
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Death += ShowNotification;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Backtrack") == 1)
            Backtrack();
    }

    private void Backtrack() => ActiveCheckPoint.BacktrackingAction.Invoke();

    private void ShowNotification()
    {
        if (_isNotificationShown)
            return;
        NewSkillNotificationController.Instance.ShowNotification(_notification);
        _isNotificationShown = true;
    }
}
