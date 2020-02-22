using System;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public float HealthPercentage => Health / MaxHealth;
    public bool IsDead => Health <= 0;

    [SerializeField] private float _mercyInvincibilityTime;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    private DashSkill _dashSkill;
    private float _mercyInvincibilityTimeLeft = 0;

    private bool _isInvincible => IsIntangible || _isMercyInvincibilityActive;

    private bool _isMercyInvincibilityActive => _mercyInvincibilityTimeLeft > 0;

    public bool IsIntangible
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

    private void Update()
    {
        _mercyInvincibilityTimeLeft -= Time.deltaTime;
        if (_mercyInvincibilityTime < 0)
            _mercyInvincibilityTime = 0;
    }

    public void Damage(int value)
    {
        if (value <= 0) return;
        if (_isInvincible) return;
        if (IsIntangible) return;
        _health -= value;
        if (_mercyInvincibilityTime > 0)
            _mercyInvincibilityTimeLeft = _mercyInvincibilityTime;
        OnValidate();
    }

    public void Heal(int value)
    {
        if (value <= 0)
            return;
        _health += value;
        OnValidate();
    }

    public void ChangeHealth(int value)
    {
        if (value < 0)
            Damage(-value);
        if (value > 0)
            Heal(value);
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
