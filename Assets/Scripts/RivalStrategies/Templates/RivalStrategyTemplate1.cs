using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RivalStrategyTemplate1 : IRivalStrategy//может стрелять обычными пулями в игрока, имеет доступ к своему здоровью
{
    protected GameObject _bulletPrefab = PrefabStorage.Instance.GetPrefab("Bullet");
    protected GameObject _player;
    protected MonoBehaviour _monoBehaviour;
    protected ShootingController _shootingController;
    protected HealthController _healthController;

    public abstract void FrameAction();

    public virtual void Initialize(MonoBehaviour monoBehaviour)
    {
        _monoBehaviour = monoBehaviour;
        _shootingController = _monoBehaviour.GetComponent<ShootingController>();
        _healthController = _monoBehaviour.GetComponent<HealthController>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }
}
