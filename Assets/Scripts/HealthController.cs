using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public float HealthPercentage => Health / MaxHealth;
    public bool IsDead => Health <= 0;

    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);

    public event HealthChangedDelegate HealthChanged;
    public event Action Death;

    public void ChangeHealth(int value)
    {
        _health += value;
        if (_health > MaxHealth)
            _health = MaxHealth;
        if (_health <= 0)
            _health = 0;
        HealthChanged?.Invoke(_health, MaxHealth);
        if (_health == 0)
            Death?.Invoke();
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health, MaxHealth);
    }
}
