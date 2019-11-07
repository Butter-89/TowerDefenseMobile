using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    // Start is called before the first frame update
  public  Camera camera;
    public float rotationSpeed = 100.0f;
    float xRot, yRot, zRot;
    public float rotSpeed = 20f;
    Gyroscope gyroscope;
    void Start()
    {
        camera = GetComponent<Camera>();
        Input.gyro.enabled = true;
        rotationSpeed = Time.deltaTime * rotationSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        xRot = Input.acceleration.z * -180f;
        // This tilts like a driving wheel to make it like shaking head no
        yRot = Input.acceleration.x * -180f;
        zRot = 0f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(xRot, 0, zRot)), Time.deltaTime * rotSpeed);
        //gyroCameraController();
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
