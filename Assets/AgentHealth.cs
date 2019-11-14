using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    public AudioSource explosion;
    void Start()
    {
        count = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Collision!");
        ProjectileMovement pm = collision.collider.GetComponentInParent<ProjectileMovement>();
        if (pm)
        {
            //this.enabled = false;
            Destroy(pm.gameObject);
            Explosion();
            Debug.Log("Destoryed!"+count);
        }

    }
    public int GetEnemyDestoriedCount
    {
        get { return count; }
    }

    public void Explosion()
    {
        explosion.Play();
        Destroy(this.gameObject, 5f);
        foreach(var renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.enabled = false;
        }
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        count++;
        
    }
}
