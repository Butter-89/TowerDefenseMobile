using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public float cameraMoveAnimationSpeed;
    public GameObject turrent;

    float xRot, yRot, zRot;
    private float sensitivity = 0.9f;
    Gyroscope gyroscope;
   public bool isMoveCamera = false;
    //debug
    private float startTime;
   public Vector3 movePosition;
    private float journeydis;
    void Start()
    {
        camera = GetComponent<Camera>();
        Input.gyro.enabled = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        //This moves the camera up and down
        xRot = Mathf.Clamp(Input.acceleration.z, -0.35f, 0.3f) * -180f;


        // This tilts like a driving wheel to make it like shaking head no
        yRot = Input.acceleration.x * -180f;
        zRot = 0f;
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(new Vector3(xRot, yRot * 1.1f, zRot)), Time.deltaTime * sensitivity);
        //turrent.transform.rotation = camera.transform.rotation;
        //gyroCameraController();
        // Debug.Log(Input.gyro.rotationRateUnbiased);
        moveCamera();
        

    }
    
    /// <summary>
    /// Moves the camera to the given position
    /// </summary>
    /// <param name="location"></param>
    private void moveCamera()
    {
        if (isMoveCamera == true)
        {
            journeydis = Vector3.Distance(camera.transform.position, movePosition);
            float fj = (Time.time) * cameraMoveAnimationSpeed / journeydis;
            camera.transform.position = Vector3.Lerp(camera.transform.position, movePosition, fj);
        }
        
    }
    

    void gyroCameraController()
    {

        Debug.Log(Input.acceleration);

    }
    private static Quaternion GyroToUnity(Quaternion gyroValues)
    {
        return new Quaternion(gyroValues.x, gyroValues.y, -gyroValues.z, -gyroValues.w);
    }
}