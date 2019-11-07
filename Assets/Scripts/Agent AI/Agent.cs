using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Node current_node;
    //public List<GameObject> wayPoints;
    private NavMeshAgent agent;
    
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent!=null)
        {
            agent.enabled = true;
            agent.isStopped = false;
            if (current_node != null)
                agent.SetDestination(current_node.transform.position);
        }
    }
    void Update()
    {
        
    } 

    private void OnTriggerEnter(Collider other)
    {
        Node nextNode = other.transform.GetComponent<Node>().GetNextNode();
        //Debug.Log("Next node: " + nextNode.name);
        //Debug.Log("Trigger: " + other.name);
        if (nextNode != null)
        {
            current_node = nextNode;
            SetAgentDestination(current_node); //???
        }
        
    }

    public void SetAgentDestination(Node i_nextNode)
    {
        agent.SetDestination(i_nextNode.transform.position);
    }

}
