using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location1Controller : SingletonMonoBehaviour<Location1Controller>
{
    [SerializeField] private string[] _introMonologue;
    [SerializeField] private string[] _phase1EndMonologue;

    private void Start()
    {
        MonologueController.Instance.ShowMonologue(_introMonologue);
        RivalStrategyController.Instance.Strategy = new RivalStrategy1_1_1();
    }

    public void ShowPhase1EndMonologue()
    {
        MonologueController.Instance.ShowMonologue(_phase1EndMonologue);
    }
}
