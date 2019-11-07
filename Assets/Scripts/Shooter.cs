using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootFrom;
    /// <summary>
    /// The rate at which a projectile is fired.
    /// </summary>
    public float FireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", FireRate);
        shootFrom = shootFrom ?? gameObject.transform;
    }

    public void Shoot()
    {
        var launched = Instantiate(projectile);
        launched.transform.position = shootFrom.position;
        launched.transform.rotation = shootFrom.rotation;
        launched.SetActive(true);
        Invoke("Shoot", FireRate);
    }
}
