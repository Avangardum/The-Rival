using UnityEngine;

public class RivalStrategy1_1_2 : RivalStrategyTemplate1
{
    private float _bulletSpeed = 10;
    private float _shootingCooldown = 1;
    private float _angularDeviation = 14;
    private float _currentShootingCooldown = 1;
    private int _selfDamagePerBullet = 1;

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
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform, -_angularDeviation);
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform, 2 *_angularDeviation);
        _shootingController.ShootAtTarget(_bulletPrefab, _bulletSpeed, _player.transform, -2 *_angularDeviation);
        _currentShootingCooldown = _shootingCooldown;
        _healthController.ChangeHealth(-_selfDamagePerBullet * 5);
    }
}