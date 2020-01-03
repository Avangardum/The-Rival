using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    private void Activate() => gameObject.SetActive(true);

    private void Deactivate() => gameObject.SetActive(false);

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Death += Activate;
        SceneManager.sceneUnloaded += Unsubscribe;
        Deactivate();
    }

    private void Unsubscribe<Scene>(Scene scene)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Death -= Activate;
    }
}
