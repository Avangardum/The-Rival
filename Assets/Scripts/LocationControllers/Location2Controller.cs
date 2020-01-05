using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location2Controller : MonoBehaviour
{
    [SerializeField] GameObject _hiddenArea1;
    [SerializeField] GameObject _veryBigBullet;
    [SerializeField] string[] _introMonologue;
    [SerializeField] string[] _battleBeginningMonologue;
    [SerializeField] string[] _battleEndMonologue;
    [SerializeField] DoorController _outerDoorController;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        BacktrackingController.Instance.ActiveCheckPoint = new Checkpoint(2 ,SceneLoader.Instance.ReloadScene);
        _outerDoorController.DoorOpened += OnOuterDoorOpen;
        _veryBigBullet.GetComponent<BulletController>().Hit += OnVeryBigBulletEscape;
    }

    private void OnOuterDoorOpen()
    {
        _hiddenArea1.SetActive(false);
        _veryBigBullet.SetActive(true);
    }

    private void OnVeryBigBulletEscape()
    {
        if (_player.GetComponent<HealthController>().IsDead)
            return;
        //TODO подвинуть камеру
        MonologueController.Instance.ShowMonologue(_introMonologue);
        RivalStrategyController.Instance.Strategy = new RivalStrategy2_1_1();
    }
}
