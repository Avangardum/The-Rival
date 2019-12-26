using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location1Controller : SingletonMonoBehaviour<Location1Controller>
{
    [SerializeField] private string[] _introMonologue;
    [SerializeField] private string[] _phase1EndMonologue;

    private GameObject _player;

    private void Start()
    {
        BacktrackingController.Instance.ActiveCheckPoint = new Checkpoint(0, RestartFight1);
        MonologueController.Instance.ShowMonologue(_introMonologue);
        RivalStrategyController.Instance.Strategy = new RivalStrategy1_1_1();
    }

    public void ShowPhase1EndMonologue()
    {
        MonologueController.Instance.ShowMonologue(_phase1EndMonologue);
    }

    public void RestartFight1() => SceneLoader.Instance.ReloadScene();
}
