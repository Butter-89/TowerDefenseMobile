﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    public AudioSource explosion;
    public GameObject explosionParticle;
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
            if (!explosion.isPlaying)
            {
                explosion.Play();
            }
            GameObject go = Instantiate(explosionParticle) as GameObject;
            go.transform.position = transform.position;
            Destroy(pm.gameObject);
            Destroy(this.gameObject);
            count++;
            explosion.Play();
            Debug.Log("Destoryed!"+count);
        }

    }
    public int GetEnemyDestoriedCount
    {
        get { return count; }
    }
}