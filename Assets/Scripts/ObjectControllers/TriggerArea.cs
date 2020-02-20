using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    public GameObject TriggeringObject;

    [SerializeField] private UnityEvent _actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == TriggeringObject)
            _actions.Invoke();
    }
}
