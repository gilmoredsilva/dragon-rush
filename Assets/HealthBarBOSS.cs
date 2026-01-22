using UnityEngine;
using UnityEngine.UI;

public class HealthBarBOSS : MonoBehaviour
{
    public Health bossHealth;
    public Image totalHealthBar;
    public Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = bossHealth.currentHealth / 100;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = bossHealth.currentHealth / 100;
    }
}
