using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class SpawnManager : MonoBehaviour
{
    public PathCreator[] path_list;
    public GameObject spawned_agent;
    public float time_interval;
    public int num_toSpawn;
    int current_num;
    private void Start()
    {
        current_num = 0;
        InvokeRepeating("Spawn", time_interval, time_interval);
    }

    void Spawn()
    {
        //randomly choose a path starting from the same point
        int path_number = Random.Range(0, path_list.Length);
        PathCreator path_chosen = path_list[path_number];
        //Instantiate an agent at the start point
        Vector3 init_position = path_chosen.path.GetPoint(0);
        Quaternion init_rotation = path_chosen.path.GetRotation(0f);
        GameObject agent = Instantiate(spawned_agent, init_position, init_rotation);
        //Attach the agent to the path
        agent.GetComponent<PathFollower>().pathCreator = path_chosen;
        current_num++;
        
        if(current_num>=num_toSpawn)
        {
            CancelInvoke("Spawn");
        }
    }
}
