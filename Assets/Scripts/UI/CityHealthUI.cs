using UnityEngine;
using UnityEngine.UI;

public class CityHealthUI : MonoBehaviour
{
    public Text healthText;

    public void SetHealthText(CityManager cm)
    {
        healthText.text = $"Planet Integrity at {cm.HealthPercentage.ToString("0")}%";
    }
}
