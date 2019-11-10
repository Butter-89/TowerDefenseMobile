using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Swipe swipeManager;
    public GameObject CameraMover;
    public float RotateSpeed; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (swipeManager.SwipeUp)
        {
           // CameraMover.transform.localEulerAngles += new Vector3(RotateSpeed, 0, 0);
            CameraMover.transform.Rotate(new Vector3(+RotateSpeed, 0, 0));
            //CameraMover.transform.eulerAngles += new Vector3(RotateSpeed, 0, 0);
            Debug.Log("up");
        }
        if (swipeManager.SwipeDown)
        {
            // CameraMover.transform.eulerAngles -= new Vector3(RotateSpeed, 0, 0);
            CameraMover.transform.Rotate(new Vector3(-RotateSpeed, 0, 0));
            Debug.Log("down");
        }
        if (swipeManager.SwipeLeft)
        {
            //CameraMover.transform.eulerAngles += new Vector3(0, RotateSpeed, 0);
            CameraMover.transform.Rotate(new Vector3(0,RotateSpeed, 0));
            Debug.Log("Left");
        }
        if (swipeManager.SwipeRight)
        {

            CameraMover.transform.Rotate(new Vector3(0, -RotateSpeed, 0));
            // CameraMover.transform.position += new Vector3(-10.0f, 0, 0);
            // CameraMover.transform.rotation = new Quaternion(CameraMover.transform.rotation.x - 10.0f, CameraMover.transform.rotation.y, CameraMover.transform.rotation.z, CameraMover.transform.rotation.w);
            Debug.Log("Right");
        }
        if (swipeManager.Tap)
        {
            Debug.Log("Tap");
        }

    }
}
