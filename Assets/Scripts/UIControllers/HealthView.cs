using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] Image _rivalHealthBar;
    [SerializeField] Image _playerHealthBar;

    private void Awake()
    {
        GameObject rival = GameObject.FindGameObjectWithTag("Rival");
        if (rival != null)
        {
            HealthController rivalHealthController = rival.GetComponent<HealthController>();
            rivalHealthController.HealthChanged += SetRivalHpBarValue;
        }
        else
        {
            SetRivalHpBarValue(0, 1);
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        HealthController playerHealthController = player.GetComponent<HealthController>();
        playerHealthController.HealthChanged += SetPlayerHpBarValue;
    }

    private void SetRivalHpBarValue(int currentHealth, int maxHealth)
    {
        _rivalHealthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    private void SetPlayerHpBarValue(int currentHealth, int maxHealth)
    {
        _playerHealthBar.fillAmount = (float)currentHealth / maxHealth;
    }

}
