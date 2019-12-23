using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Health => _health;
    public int MaxHealth => _maxHealth;

    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public event Action<int> HealthChanged;
    public event Action Death;

    public void ChangeHealth(int value)
    {
        _health += value;
        if (_health > MaxHealth)
            _health = MaxHealth;
        if (_health <= 0)
            _health = 0;
        HealthChanged?.Invoke(_health);
        if (_health == 0)
            Death?.Invoke();
    }
}
