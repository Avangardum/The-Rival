using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int _damage;

    public event Action Hit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthController otherHealthController = collision.gameObject.GetComponent<HealthController>();
        otherHealthController?.ChangeHealth(-_damage);
        Destroy(gameObject);
        Hit?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<CircleCollider2D>().isTrigger = false;
    }
}
