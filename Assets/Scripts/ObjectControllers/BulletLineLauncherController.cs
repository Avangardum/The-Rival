using UnityEngine;

public class BulletLineLauncherController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _lineLength;
    [SerializeField] private float _bulletsDistance;
    [SerializeField] private float _cooldown;

    private float _currentCooldown = 0;

    private void Update()
    {
        _currentCooldown.DecreaseCooldown(DecreaseCooldownMode.Update);
    }

    private void FixedUpdate()
    {
        if (_currentCooldown == 0)
            Shoot();
    }

    private void Shoot()
    {
        _currentCooldown = _cooldown;
        _direction.Normalize();
        Vector2 lineBuildingDirection = _direction.TurnedAroundOrigin(-90);
        Vector2 startingPoint = (Vector2)transform.position - lineBuildingDirection.normalized * (_lineLength / 2);
        Vector2 endingPoint = (Vector2)transform.position + lineBuildingDirection.normalized * (_lineLength / 2);
        Vector2 step = lineBuildingDirection * _bulletsDistance;
        for (Vector2 currentPos = startingPoint; (currentPos - startingPoint).sqrMagnitude <= _lineLength * _lineLength; currentPos += step)
        {
            GameObject bullet = Instantiate(_bulletPrefab, currentPos, Quaternion.identity);
            bullet.transform.LookAt2D(currentPos + _direction);
            bullet.GetComponent<Rigidbody2D>().velocity = _direction * _speed;
        }
    }
}
