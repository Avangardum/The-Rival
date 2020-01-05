using UnityEngine;

public class RivalStrategy2_1_1 : RivalStrategyTemplate1
{
    private const float RING_COOLDOWN = 3;
    private const float MAX_GAP_ROTATION = 90;
    private const float NEXT_PHASE_HEALTH_PERCENTAGE = 0.5f;

    private BulletRingLauncher _bulletRingLauncher;
    private float _currentRingCooldown = 0;

    public override void FrameAction()
    {
        if (_currentRingCooldown > 0)
            _currentRingCooldown -= Time.deltaTime;
        else
        {
            Vector2 directionToPlayer = _player.transform.position - _monoBehaviour.transform.position;
            Vector2 gapDirection = directionToPlayer.TurnedAroundOrigin(Random.Range(-MAX_GAP_ROTATION, MAX_GAP_ROTATION));
            _bulletRingLauncher.LaunchRing(gapDirection);
            _currentRingCooldown = RING_COOLDOWN;
        }
    }

    public override void Initialize(MonoBehaviour monoBehaviour)
    {
        base.Initialize(monoBehaviour);
        _bulletRingLauncher = _monoBehaviour.GetComponent<BulletRingLauncher>();
        _healthController.HealthChanged += NextPhaseCheck;
    }

    private void NextPhaseCheck(int currentHealth, int maxHealth)
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        if (healthPercentage <= NEXT_PHASE_HEALTH_PERCENTAGE)
            NextPhase();
    }

    private void NextPhase()
    {
        var newStrategy = new RivalStrategy2_1_2();
        newStrategy.CurrentRingCooldown = _currentRingCooldown;
        RivalStrategyController.Instance.Strategy = newStrategy;
        _healthController.HealthChanged -= NextPhaseCheck;
    }
}
