using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTest : MonoBehaviour
{
    [SerializeField] private string[] _monologue;

    private void Start()
    {
        MonologueController.Instance.ShowMonologue(_monologue);
    }
}
