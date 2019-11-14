using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobHealth : MonoBehaviour
{
    public int health = 20;
    public AudioSource explosion;
    public GameObject explosionParticle;
    private GameData data;
    void Start()
    {
        data = GameObject.Find("GameManager").GetComponent<GameData>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        ProjectileMovement pm = collision.collider.GetComponentInParent<ProjectileMovement>();
        if (pm)
        {
            //this.enabled = false;
            //if (!explosion.isPlaying)
            //{
            //    explosion.Play();
            //}
            health--;
            Destroy(pm.gameObject);
            if(health<=0)
            {
                Explode();
            }
            
        }
    }
    public void Explode()
    {
        GameObject go = Instantiate(explosionParticle) as GameObject;
        go.transform.position = transform.position;
        explosion.Play();
        foreach (var renderer in GetComponentsInChildren<MeshRenderer>())
        {
            renderer.enabled = false;
        }
        
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<TrailRenderer>().enabled = false;
        data.score += 3;
        Destroy(this.gameObject, 5f);
    }
}
