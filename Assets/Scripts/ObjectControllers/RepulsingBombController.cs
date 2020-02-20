using System.Linq;
using System.Timers;
using UnityEngine;

public class RepulsingBombController : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _damageAtEpicenter;
    [SerializeField] private float _repulsionAtEpicenter;
    [SerializeField] private float _disableMovementTime;

    public void Explode()
    {
        var affectedObjects = Physics2D.OverlapCircleAll(transform.position, _explosionRadius).Select(x => x.gameObject);
        affectedObjects = affectedObjects.Where(x => x.CompareTag("Player"));
        foreach(var obj in affectedObjects)
        {
            var _playerMovement = obj.GetComponent<PlayerMovement>();
            _playerMovement.IsEnabled = false;
            _playerMovement.Invoke(nameof(_playerMovement.Enable), _disableMovementTime);
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            float impact = 1 - distance / _explosionRadius;//impact = 1 - макс. эффект     impact = 0 - нет эффекта
            obj.GetComponent<HealthController>().Damage((int)(_damageAtEpicenter * impact));
            Vector2 repulsion = (obj.transform.position - transform.position).normalized;
            repulsion *= _repulsionAtEpicenter * impact;
            var rigidbody2D = obj.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(repulsion, ForceMode2D.Impulse);
        }
        GameObject.Destroy(gameObject);
    }

    private void Awake()
    {
        GetComponentInChildren<TriggerArea>().TriggeringObject = GameObject.FindGameObjectWithTag("Player");
    }
}
