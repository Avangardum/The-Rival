using UnityEngine;

public class FallingController : MonoBehaviour
{
    [SerializeField] private bool _isEnabled;

    [SerializeField] private LayerMask _platformsLayerMask;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _offsetWhenReturning;
    [SerializeField] private int _fallDamage;

    private HealthController _healthController;
    private DashSkill _dashSkill;
    private Vector2 _lastSafePosition;
    private bool isImmuneToFalling
    {
        get
        {
            if (_dashSkill != null)
                if (_dashSkill.IsDashing)
                    return true;
            return false;
        }
    }

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _dashSkill = GetComponent<DashSkill>();
    }

    private void FixedUpdate()
    {
        if (_isEnabled)
            return;
        var colliders = Physics2D.OverlapCircleAll(transform.position, _groundCheckRadius, _platformsLayerMask);
        if (colliders.Length > 0)
        {
            _lastSafePosition = transform.position;
        }
        else
            if(!isImmuneToFalling)
                Fall();
    }

    private void Fall()
    {
        _healthController.Damage(_fallDamage);
        Vector2 offset = (_lastSafePosition - (Vector2)transform.position).normalized * _offsetWhenReturning;
        transform.position = _lastSafePosition + offset;
    }
}
