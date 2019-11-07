using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    /// <summary>
    /// The speed at which the projectile flies.
    /// </summary>
    public float ProjectileVelocity = 1f;

    /// <summary>
    /// The maximum lifetime of this projectile.
    /// </summary>
    public float MaxLifetime = 15f;

    private float currentLifetime = 0f;
    public float CurrentLifetime
    {
        get => currentLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, ProjectileVelocity * Time.deltaTime, 0, Space.Self);
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= MaxLifetime)
            Destroy(gameObject);
    }
}
