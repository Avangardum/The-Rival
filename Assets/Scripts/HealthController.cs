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

    private DashSkill _dashSkill;
    private bool _isInvincible
    {
        get
        {
            if (_dashSkill != null)
                if (_dashSkill.IsDashing)
                    return true;
            return false;
        }
    }

    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);

    public event HealthChangedDelegate HealthChanged;
    public event Action Death;

    private void Awake()
    {
        _dashSkill = GetComponent<DashSkill>();
    }

    public void Damage(int value)
    {
        if (value <= 0 || _isInvincible)
            return;
        ChangeHealth(-value);
    }

    public void Heal(int value)
    {
        if (value <= 0)
            return;
        ChangeHealth(value);
    }

    public void ChangeHealth(int value)
    {
        _health += value;
        OnValidate();
    }

    private void Start()
    {
        HealthChanged?.Invoke(_health, MaxHealth);
    }

    private void OnValidate()
    {
        if (_health > MaxHealth)
            _health = MaxHealth;
        if (_health <= 0)
            _health = 0;
        HealthChanged?.Invoke(_health, MaxHealth);
        if (_health == 0)
            Death?.Invoke();
    }
}
