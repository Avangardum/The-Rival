using System.Collections.Generic;
using UnityEngine;

public class SwordOfChaosSkill : MonoBehaviour
{
    [SerializeField] private GameObject _swordPrefab;
    [SerializeField] private float _swingAngle;
    [SerializeField] private float _swingTime;
    [SerializeField] private float _swordDistance;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _damage;

    private List<GameObject> _hitObjects;
    private GameObject _sword;
    private float _commitedRotation;
    private float _currentCooldown;

    private void Update()
    {
        if (Input.GetAxisRaw("Fire1") == 1 && _sword == null && _currentCooldown == 0f)
            StartSwinging();
    }

    private void FixedUpdate()
    {
        if (_sword != null)
        {
            float rotationAnglePerFixedFrame = (_swingAngle * Time.fixedDeltaTime) / _swingTime;
            _sword.transform.RotateAround(transform.position, Vector3.forward, -rotationAnglePerFixedFrame);
            _commitedRotation += rotationAnglePerFixedFrame;
            if (_commitedRotation > _swingAngle)
            {
                float overflow = _commitedRotation - _swingAngle;
                _sword.transform.RotateAround(transform.position, Vector3.forward, overflow);
                _commitedRotation -= overflow;
            }
            if (_commitedRotation >= _swingAngle)
            {
                Destroy(_sword);
                _currentCooldown = _cooldown;
            }
        }
        _currentCooldown -= Time.fixedDeltaTime;
        if (_currentCooldown < 0)
            _currentCooldown = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hitObjects.Contains(collision.gameObject))
            return;
        _hitObjects.Add(collision.gameObject);
        Hit(collision.gameObject);
    }

    private void StartSwinging()
    {
        Vector2 mousePosition = StaticFunctions.GetWorldMousePositions();
        Vector2 directionFromPlayerToMouse = mousePosition - (Vector2)transform.position;
        directionFromPlayerToMouse = directionFromPlayerToMouse.normalized * _swordDistance;
        Vector2 directionFromPlayerToSword = directionFromPlayerToMouse.RotateAroundOrigin(_swingAngle / 2);
        _sword = Instantiate(_swordPrefab, (Vector2)transform.position + directionFromPlayerToSword, Quaternion.identity, transform);
        _sword.transform.LookFrom2D(transform);
        _commitedRotation = 0f;
        _hitObjects = new List<GameObject>();
    }

    private void Hit(GameObject target)
    {
        HealthController healthController = target.GetComponent<HealthController>();
        healthController?.ChangeHealth(-_damage);
    }
}
