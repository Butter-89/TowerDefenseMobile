using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;

    /// <summary>
    /// The rate at which a projectile is fired.
    /// </summary>
    public float FireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", FireRate);
    }

    public void Shoot()
    {
        //projectile.transform.position = gameObject.transform.position;
        //projectile.transform.rotation = gameObject.transform.rotation;
        var launched = Instantiate(projectile);
        launched.transform.position = gameObject.transform.position;
        launched.transform.rotation = gameObject.transform.rotation;
        launched.SetActive(true);
        Invoke("Shoot", FireRate);
    }
}
