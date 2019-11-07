using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private NavMeshAgent agent;
    public List<GameObject> wayPoints;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent!=null)
        {
            agent.enabled = true;
            agent.isStopped = false;
            if (wayPoints[0] != null)
                agent.SetDestination(wayPoints[0].transform.position);
        }
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger: " + other.name);
        if (other.transform.GetComponent<Node>())
        {
            
        }
    }

}
