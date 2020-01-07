using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
    [SerializeField] private GameObject _triggeringObject;
    [SerializeField] private UnityEvent _actions;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _triggeringObject)
            _actions.Invoke();
    }
}
