using UnityEngine;
using UnityEngine.Events;

public class CityManager : MonoBehaviour
{
    public short CityHealth = 10;

    private short maxHealth;
    public short MaxHealth
    {
        get => maxHealth;
    }

    public float HealthPercentage
    {
        get => CityHealth / (float)maxHealth * 100;
    }

    [System.Serializable]
    public class AreaAttackedEvent : UnityEvent { }

    public AreaAttackedEvent OnAreaAttacked;

    [System.Serializable]
    public class AreaDestroyedEvent : UnityEvent { }

    public AreaDestroyedEvent OnAreaDestroyed;

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
           // Debug.Log(CityHealth);
            OnAreaAttacked.Invoke();
            // Game over
            if (CityHealth <= 0)
            {
                Debug.Log("Game over");
                OnAreaDestroyed.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}
