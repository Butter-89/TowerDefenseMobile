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
    bool isMoveCamer = false;
    //debug
    private float startTime;
    private float journeydis;
    void Start()
    {
        camera = GetComponent<Camera>();
        Input.gyro.enabled = true;
        journeydis = Vector3.Distance(camera.transform.position, new Vector3(-36.0f, 13.0f, -51.0f));
        
    }

    // Update is called once per frame
    void Update()
    {
        //This moves the camera up and down
        xRot = Mathf.Clamp(Input.acceleration.z ,-0.35f, 0.3f)* -180f;
        

        // This tilts like a driving wheel to make it like shaking head no
        yRot = Input.acceleration.x * -180f;
        zRot = 0f;
       camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(new Vector3(xRot, yRot*1.1f, zRot)), Time.deltaTime * sensitivity);
        //gyroCameraController();
       Debug.Log(Input.gyro.rotationRateUnbiased);
        moveCamera();
        
    }
    public void isMoveCameraaa()
    {
        isMoveCamer = true;
    }
    void moveCamera()
    {
        if (isMoveCamer == true)
        {
            float fj = Time.deltaTime*5f / journeydis;
            camera.transform.position = Vector3.Lerp(camera.transform.position, new Vector3(-36.0f, 13.0f, -51.0f), 0.01f);
        }
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
