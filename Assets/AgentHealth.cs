using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
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
            Destroy(this.gameObject);
            count++;
            Debug.Log("Destoryed!"+count);
        }

    }
    public int GetEnemyDestoriedCount
    {
        get { return count; }
    }
}
