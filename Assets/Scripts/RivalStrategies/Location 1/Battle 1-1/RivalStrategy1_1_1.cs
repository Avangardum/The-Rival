using UnityEngine;

public class RivalStrategy1_1_1 : IRivalStrategy
{
    private GameObject _bulletPrefab = PrefabStorage.Instance.GetPrefab("Bullet");
    private GameObject _player;
    private MonoBehaviour _monoBehaviour;
    private ShootingController _shootingController;
    private float _bulletSpeed = 10;
    private float _shootingCooldown = 1;
    private float _angularDeviation = 18;
    private float _currentShootingCooldown = 1;

    public void FrameAction()
    {
        if (_currentShootingCooldown == 0)
            Shoot();
        DecreaseCooldowns();
    }

    public void Initialize(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
        _shootingController = _monoBehaviour.GetComponent<ShootingController>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void DecreaseCooldowns()
    {
        _currentShootingCooldown -= Time.deltaTime;
        if (_currentShootingCooldown < 0)
            _currentShootingCooldown = 0;
    }

    private void Shoot()
    {
        _shootingController.Shoot(_bulletPrefab, _bulletSpeed, _player.transform);
        _shootingController.Shoot(_bulletPrefab, _bulletSpeed, _player.transform, _angularDeviation);
        _shootingController.Shoot(_bulletPrefab, _bulletSpeed, _player.transform, - _angularDeviation);
        _currentShootingCooldown = _shootingCooldown;
    }
}
