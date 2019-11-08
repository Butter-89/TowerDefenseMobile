using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    public PathCreator pathToFollow;
    public float speed = 5f;
    private float distanceTravelled;

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathToFollow.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathToFollow.path.GetRotationAtDistance(distanceTravelled);
    }
}
