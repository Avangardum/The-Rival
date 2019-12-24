using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] Image _rivalHealthBar;
    [SerializeField] Image _playerHealthBar;

    private void Awake()
    {
        HealthController rivalHealthController = GameObject.FindGameObjectWithTag("Rival").GetComponent<HealthController>();
        HealthController playerHealthController = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        rivalHealthController.HealthChanged += SetRivalHpBarValue;
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
