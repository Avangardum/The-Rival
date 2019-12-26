using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenController : MonoBehaviour
{
    private void Activate() => gameObject.SetActive(true);

    private void Deactivate() => gameObject.SetActive(false);

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Death += Activate;
        Deactivate();
    }
}
