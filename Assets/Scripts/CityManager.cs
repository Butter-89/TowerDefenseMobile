using UnityEngine;

public class CityManager : MonoBehaviour
{
    public byte CityHealth = 10;

    private void OnCollisionEnter(Collision collision)
    {
        var parent = collision.collider.GetComponent<Agent>();
        if (parent)
        {
            Destroy(parent.gameObject);
            --CityHealth;
            // Game over
            if (CityHealth == 0)
                Destroy(gameObject);
        }
    }
}
