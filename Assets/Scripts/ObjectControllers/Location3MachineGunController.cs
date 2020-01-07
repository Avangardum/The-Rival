using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootingController))]
public class Location3MachineGunController : MonoBehaviour
{
    [System.Serializable]
    private enum BulletType
    {
        RealBullet,
        FakeBullet
    }

    [SerializeField] private GameObject _realBulletPrefab;
    [SerializeField] private GameObject _fakeBulletPrefab;
    [SerializeField] private List<BulletType> _bullets;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _speed;

    private ShootingController _shootingController;
    private float _currentCooldown;

    private void Awake()
    {
        _shootingController = GetComponent<ShootingController>();
    }

    private void Update()
    {
        _currentCooldown -= Time.deltaTime;
        if (_currentCooldown < 0)
            _currentCooldown = 0;
    }

    private void FixedUpdate()
    {
        if (_currentCooldown > 0 || _bullets.Count == 0)
            return;
        BulletType bulletType = _bullets[_bullets.Count - 1];
        _bullets.RemoveAt(_bullets.Count - 1);
        GameObject bulletPrefab = bulletType == BulletType.RealBullet ? _realBulletPrefab : _fakeBulletPrefab;
        _shootingController.ShootInDirection(bulletPrefab, _speed, Vector2.down);
        _currentCooldown = _cooldown;
    }
}
