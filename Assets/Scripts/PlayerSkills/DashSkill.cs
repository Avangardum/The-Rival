using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    public bool IsEnabled;

    public bool IsDashing { get; private set; } = false;

    [SerializeField] private float _distance;
    [SerializeField] private float _time;
    [SerializeField] private float _cooldown;

    private Vector2 _initialPosition;
    private Vector2 _finalPosition;
    private float _timePassed;
    private float _currentCooldown = 0;
    
    private HealthController _healthController;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void Dash(Vector2 direction)
    {
        if (!IsEnabled || _currentCooldown > 0 || IsDashing)
            return;
        IsDashing = true;
        _timePassed = 0f;
        _initialPosition = transform.position;
        _finalPosition = (Vector2)transform.position + direction.normalized * _distance;
        GetComponent<SpriteRenderer>().color = Color.red;
        
    }

    private void FixedUpdate()
    {
        if (!IsDashing)
            return;
        _timePassed += Time.fixedDeltaTime;
        float completion = _timePassed / _time;
        if (completion > 1)
            completion = 1;
        transform.position = Vector2.Lerp(_initialPosition, _finalPosition, completion);
        if(completion == 1)
        {
            IsDashing = false;
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        _currentCooldown = _cooldown;
    }

    private void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown < 0)
            _currentCooldown = 0;
    }
}
