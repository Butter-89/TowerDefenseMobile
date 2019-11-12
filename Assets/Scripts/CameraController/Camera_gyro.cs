using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    public TouchDetection touch;
    public SwipeDetection swipe;

    // Start is called before the first frame update
    public Camera camera;
    
    public float cameraMoveAnimationSpeed;
    public GameObject turrent;
    float xRot, yRot, zRot;
    private float sensitivity = 0.9f;
    Gyroscope gyroscope;
   public bool isMoveCamera = false;
    //debug

    public string tagName;
    private float startTime;
   public Vector3 movePosition;
    private float journeydis;

    public Transform towerTransform;
    public GameObject MainCamera;
    /// <summary>
    /// Add the camera here
    /// </summary>
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    AudioListener MainCameraAudioListener;
    AudioListener audioListenerCamera1;
    AudioListener audioListenerCamera2;
    AudioListener audioListenerCamera3;
    void Start()
    {
        camera = MainCamera.GetComponent<Camera>();
        Input.gyro.enabled = true;

        MainCameraAudioListener = MainCamera.GetComponent<AudioListener>();
        audioListenerCamera1 = camera1.GetComponent<AudioListener>();
        audioListenerCamera2 = camera2.GetComponent<AudioListener>();
        audioListenerCamera3 = camera3.GetComponent<AudioListener>();


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
        //Debug.Log("camera"+camera.name);

    }
    
    /// <summary>
    /// Moves the camera to the given position
    /// </summary>
    /// <param name="location"></param>
    private void moveCamera()
    {
        //Debug.Log("yes");
        if (isMoveCamera == true)
        {
            //Debug.Log("no");
            journeydis = Vector3.Distance(camera.transform.position, movePosition);
            float fj = (Time.time) * cameraMoveAnimationSpeed / journeydis;
            camera.transform.position = Vector3.Lerp(camera.transform.position, movePosition, fj);
            if (camera.transform.position == movePosition)
            {
                swipe.isTouchEnabled = false;
                MainCamera.GetComponent<Camera>().enabled = false ;
                MainCameraAudioListener.enabled = false;


                if (tagName == "Tower")
                {
                     camera1.SetActive(true);
                    audioListenerCamera1.enabled = true;
                    camera = camera1.GetComponent<Camera>();


                }
                if (tagName == "Tower1")
                {
                    camera2.SetActive(true);

                    audioListenerCamera2.enabled = true;

                    camera = camera2.GetComponent<Camera>();
                }
                if (tagName == "Tower2")
                {
                    camera3.SetActive(true);

                    audioListenerCamera3.enabled = true;

                    camera = camera3.GetComponent<Camera>();
                }

                towerTransform.rotation = camera.transform.rotation;

            }
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