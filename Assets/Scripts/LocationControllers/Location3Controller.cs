using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location3Controller : MonoBehaviour
{
    [SerializeField] private string[] _introMonologue;
    [SerializeField] private string[] _endMonologue;

    private void Start()
    {
        BacktrackingController.Instance.ActiveCheckpoint = new Checkpoint(SceneLoader.Instance.ReloadScene);
        MonologueController.Instance.ShowMonologue(_introMonologue);
    }

    public void End()
    {
        MonologueController.Instance.ShowMonologue(_endMonologue);
    }
}
