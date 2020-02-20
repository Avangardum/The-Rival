using System.Linq;
using UnityEngine;

public class RepulsingBombController : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private int _damageAtEpicenter;
    [SerializeField] private float _repulsionAtEpicenter;

    public void Explode()
    {
        var affectedObjects = Physics2D.OverlapCircleAll(transform.position, _explosionRadius).Select(x => x.gameObject);
        affectedObjects = affectedObjects.Where(x => x.CompareTag("Player") || x.CompareTag("Rival"));
        foreach(var obj in affectedObjects)
        {
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            float impact = 1 - distance / _explosionRadius;//impact = 1 - макс. эффект     impact = 0 - нет эффекта
            obj.GetComponent<HealthController>().Damage((int)(_damageAtEpicenter * impact));
            Vector2 repulsion = (obj.transform.position - transform.position).normalized;
            repulsion *= _repulsionAtEpicenter * impact;
            obj.GetComponent<Rigidbody2D>().AddForce(repulsion, ForceMode2D.Impulse);
            print("Hit " + impact);
        }
        GameObject.Destroy(gameObject);
    }

    private void Awake()
    {
        GetComponentInChildren<TriggerArea>().TriggeringObject = GameObject.FindGameObjectWithTag("Player");
    }
}
