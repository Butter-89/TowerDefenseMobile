using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    // Start is called before the first frame update
    private  Camera camera;
   
    float xRot, yRot, zRot;
    private float sensitivity =0.9f;
    Gyroscope gyroscope;
    void Start()
    {
        camera = GetComponent<Camera>();
        Input.gyro.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        //This moves the camera up and down
        xRot = Input.acceleration.z * -180f;
        // This tilts like a driving wheel to make it like shaking head no
        yRot = Input.acceleration.x * -180f;
        zRot = 0f;
       camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(new Vector3(xRot, yRot*1.1f, zRot)), Time.deltaTime * sensitivity);
        //gyroCameraController();
        Debug.Log(Input.acceleration);
        
    }
    void gyroCameraController()
    {

        Debug.Log(Input.acceleration);
        
    }
    private static Quaternion GyroToUnity(Quaternion gyroValues)
    {
        return new Quaternion(gyroValues.x, gyroValues.y, -gyroValues.z , - gyroValues.w);
    }
}
