using UnityEngine;

public class CityManager : MonoBehaviour
{
    public byte CityHealth = 10;

    private byte maxHealth;
    public byte MaxHealth
    {
        get => maxHealth;
    }

    public float HealthPercentage
    {
        get => CityHealth / (float)maxHealth * 100;
    }

    public void Start()
    {
        maxHealth = CityHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        var parent = other.GetComponent<Agent>();
        if (parent)
        {
            Destroy(parent.gameObject);
            --CityHealth;
            // Game over
            if (CityHealth == 0)
            {
                Debug.Log("Game over");
                gameObject.SetActive(false);
            }
        }
    }
}
