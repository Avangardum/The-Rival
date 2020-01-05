using UnityEngine;

public class RivalStrategy2_1_2 : RivalStrategyTemplate1
{
    private const float RING_COOLDOWN = 3;
    private const float MIN_GAP_ROTATION = 100;
    private const float MAX_GAP_ROTATION = 260;

    public float CurrentRingCooldown;

    private BulletRingLauncher _bulletRingLauncher;
    private Vector2 _lastGapDirection;

    public override void FrameAction()
    {
        if (CurrentRingCooldown > 0)
            CurrentRingCooldown -= Time.deltaTime;
        else
        {
            Vector2 gapDirection = _lastGapDirection.TurnedAroundOrigin(Random.Range(MIN_GAP_ROTATION, MAX_GAP_ROTATION));
            _bulletRingLauncher.LaunchRing(gapDirection);
            CurrentRingCooldown = RING_COOLDOWN;
            _lastGapDirection = gapDirection;
        }
    }

    public override void Initialize(MonoBehaviour monoBehaviour)
    {
        base.Initialize(monoBehaviour);
        _bulletRingLauncher = _monoBehaviour.GetComponent<BulletRingLauncher>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _lastGapDirection = Vector2.right.TurnedAroundOrigin(Random.Range(0, 360));
    }
}
