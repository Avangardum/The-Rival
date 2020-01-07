using UnityEngine;

public class RivalStrategy1_1_1 : RivalStrategyTemplate1
{
    private float _bulletSpeed = 10;
    private float _shootingCooldown = 1;
    private float _angularDeviation = 18;
    private float _currentShootingCooldown = 1;
    private float _nextPhaseHealthPercentage = 0.6f;
    private int _selfDamagePerBullet = 1;

    public override void Initialize(MonoBehaviour monoBehaviour)
    {
        base.Initialize(monoBehaviour);
        _healthController.HealthChanged += NextPhaseCheck;
    }

    public override void FrameAction()
    {
        if (_currentShootingCooldown == 0)
            Shoot();
        DecreaseCooldowns();
    }

    private void DecreaseCooldowns()
    {
        _currentShootingCooldown -= Time.deltaTime;
        if (_currentShootingCooldown < 0)
            _currentShootingCooldown = 0;
    }

    private void Shoot()
    {
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform);
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform, _angularDeviation);
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform, - _angularDeviation);
        _currentShootingCooldown = _shootingCooldown;
        _healthController.ChangeHealth(-_selfDamagePerBullet * 3);
    }

    private void NextPhase()
    {
        _healthController.HealthChanged -= NextPhaseCheck;
        RivalStrategyController.Instance.Strategy = new RivalStrategy1_1_2();
        Location1Controller.Instance.ShowPhase1EndMonologue();
    }

    private void NextPhaseCheck(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        if (healthPercentage <= _nextPhaseHealthPercentage)
            NextPhase();
    }
}
