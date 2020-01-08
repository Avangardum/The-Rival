using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject Origin;

    [SerializeField] private int _damage;

    private bool _hasLeftOrigin = false;

    public event Action Hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_hasLeftOrigin && collision.gameObject == Origin)
            return;
        if (collision.gameObject.CompareTag("Sword"))
            return;
        HealthController otherHealthController = collision.gameObject.GetComponent<HealthController>();
        if (otherHealthController.IsIntangible)
            return;
        otherHealthController?.ChangeHealth(-_damage);
        Destroy(gameObject);
        Hit?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _hasLeftOrigin = true;
    }
}
