using UnityEngine;
using UnityEngine.UI;

public class CityHealthUI : MonoBehaviour
{
    public Text healthText;
    public Text ScoreText;

   
    public void SetHealthText(CityManager cm)
    {
        healthText.text = $"Health: {cm.HealthPercentage.ToString("0")}%";
    }
    public void SetScoreText(AgentHealth agentHealth)
    {
        ScoreText.text = $"Score: {agentHealth.GetEnemyDestoriedCount.ToString() }%";
    }
}
