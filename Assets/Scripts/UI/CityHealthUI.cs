using UnityEngine;
using UnityEngine.UI;

public class CityHealthUI : MonoBehaviour
{
    public Text healthText;

    public void SetHealthText(CityManager cm)
    {
        healthText.text = $"Health: {cm.HealthPercentage.ToString("0")}%";
    }
}
