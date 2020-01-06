using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    public bool IsEnabled;

    [SerializeField] private float _distance;
    [SerializeField] private float _time;
    
    private HealthController _healthController;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void Dash(Vector2 direction)
    {
        if (!IsEnabled)
            return;
    }
}
