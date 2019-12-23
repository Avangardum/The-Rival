using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location1Controller : MonoBehaviour
{
    [SerializeField] private string[] _introMonologue;

    void Start()
    {
        MonologueController.Instance.ShowMonologue(_introMonologue);
        RivalStrategyController.Instance.Strategy = new IncrementLogRivalStrategy();
    }
}
