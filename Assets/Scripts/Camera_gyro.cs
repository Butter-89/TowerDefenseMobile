using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    // Start is called before the first frame update
  public  Camera camera;
  Gyroscope gyroscope;
    void Start()
    {
        camera = GetComponent<Camera>();
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        gyroCameraController();
    }
    void gyroCameraController()
    {
        camera.transform.rotation = new Quaternion(0,-Input.acceleration.y*Time.deltaTime*1.0f,Input.acceleration.z*Time.deltaTime*2f,0);
    }
    private static Quaternion GyroToUnity(Quaternion gyroValues)
    {
        return new Quaternion(gyroValues.x, gyroValues.y, -gyroValues.z , - gyroValues.w);
    }
}
