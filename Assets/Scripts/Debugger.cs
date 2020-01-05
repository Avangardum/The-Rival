using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] private bool _isEnabled;
    [SerializeField] private bool _showTimeScale;

    void Update()
    {
        if (!_isEnabled)
            return;
        string message = "Debug";
        if (_showTimeScale)
            message += $"\nTimeScale = {Time.timeScale}";
        print(message);
    }
}
