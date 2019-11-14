using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    public TouchDetection touch;
    public Swipe swipe;

    /// <summary>
    /// Controls the rotation speed of the selected tower
    /// </summary>
    public float TurrentRotationSpeed = 10f;
    // Start is called before the first frame update
    public float cameraMoveAnimationSpeed;

    private float xRot, yRot, zRot;
    public float sensitivity = 1.5f;
    private Gyroscope gyroscope;

    [HideInInspector]
    public bool isMoveCamera = false;
    [HideInInspector]
    public Vector3 movePosition;
    [HideInInspector]
    public string tagName;
    [HideInInspector]
    public Camera camera;
    [HideInInspector]
    public Transform towerTransform;
    [HideInInspector]
    public Quaternion initialTowerRotation;
    //debug
    public GameObject cameraPlaceHolder;

    private float startTime;
    private float journeydis;
    private Vector3 MainCameraLocation;
    private Quaternion MainCameraRotation;

    public GameObject MainCamera;
    /// <summary>
    /// Add the camera here
    /// </summary>
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;

    private Transform cam1Pos;
    private Transform cam2Pos;
    private Transform cam3Pos;
    private Transform cam4Pos;


    AudioListener MainCameraAudioListener;
    AudioListener audioListenerCamera1;
    AudioListener audioListenerCamera2;
    AudioListener audioListenerCamera3;
    AudioListener audioListenerCamera4;

    float fj;
    int flagMainMenu = 0;
    int cameraRotationFlag = 0;
    public bool isBackToMenu = false;
    void Start()
    {
        camera = MainCamera.GetComponent<Camera>();
        Input.gyro.enabled = false;
        MainCameraLocation = camera.transform.position;
        MainCameraRotation = camera.transform.rotation;
        MainCameraAudioListener = MainCamera.GetComponent<AudioListener>();
        audioListenerCamera1 = camera1.GetComponent<AudioListener>();
        audioListenerCamera2 = camera2.GetComponent<AudioListener>();
        audioListenerCamera3 = camera3.GetComponent<AudioListener>();
        audioListenerCamera4 = camera4.GetComponent<AudioListener>();

        //Xiubo edited here!
        cam1Pos = camera1.transform;
        cam2Pos = camera2.transform;
        cam3Pos = camera3.transform;
        cam4Pos = camera4.transform;

       
        //=================
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(towerManager.getInitialRotation);

        moveCamera();
        BackToMenu();
        //Debug.Log(isBackToMenu);
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
            Input.gyro.enabled = true;
            // Camera gyro controller.
            xRot = Mathf.Clamp(Input.acceleration.z, -0.35f, 0.3f) * -180f;
            //yRot = Mathf.Clamp( Input.acceleration.x ,-0.35f, 0.3f)* 180f;
            yRot = Input.acceleration.x * 180f;
            zRot = 0f;
            //camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(new Vector3(xRot, yRot * 1.1f, zRot)), Time.deltaTime * sensitivity);

            if (Input.touchCount > 0)
            {
                Touch touchTest = Input.GetTouch(0);
                if (touchTest.phase == TouchPhase.Moved)
                {
                    Vector2 current = touchTest.deltaPosition;
                    camera.transform.Rotate(new Vector3(current.y, current.x, 0) * Time.deltaTime * TurrentRotationSpeed);
                    towerTransform.rotation = camera.transform.rotation;
                }
                else if (touchTest.phase == TouchPhase.Ended || touchTest.phase == TouchPhase.Canceled)
                {
                    camera.transform.Rotate(Vector3.zero);
                }
            }

            //Code to move the camera to the selected tower
            journeydis = Vector3.Distance(MainCamera.transform.position, movePosition);

            fj = (Time.deltaTime) * cameraMoveAnimationSpeed / journeydis * 100;
            //Debug.Log("this is in camera"+movePosition);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, movePosition, fj);
            //Debug.Log("Moving Camera" + MainCamera.transform.position);
            //if (  MainCamera.transform.position == movePosition && journeydis ==0)
            //{
            //    Debug.Log("Called?");
            //    towerTransform.rotation = camera.transform.rotation;
            //}



            if (cameraRotationFlag == 0)
            {

                if (journeydis == 0 || MainCamera.transform.position == movePosition)
                {
                    //  MainCamera.transform.rotation = MainCameraRotation;
                    cameraPlaceHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
                    towerTransform.rotation = initialTowerRotation;

                    swipe.enable = false;
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
                        // Debug.Log(movePosition);
                        camera3.SetActive(true);

                        audioListenerCamera3.enabled = true;

                        camera = camera3.GetComponent<Camera>();
                    }
                    if (tagName == "Tower3")
                    {
                        // Debug.Log(movePosition);
                        camera4.SetActive(true);

                        audioListenerCamera4.enabled = true;

                        camera = camera4.GetComponent<Camera>();
                    }
                    cameraRotationFlag = 1;
                }
                // towerTransform.rotation = camera.transform.rotation;
            }
        }

    }

    public void ButtonClick()
    {
        isBackToMenu = true;
        isMoveCamera = false;
        journeydis = 0;
        swipe.enable = true;
        flagMainMenu = 0;
        cameraRotationFlag = 0;
    }
    private void BackToMenu()
    {
        //Debug.Log("clicked" + isBackToMenu);
        if (isBackToMenu == true)
        {

            resetCamera();
            //camera = MainCamera.GetComponent<Camera>();

            journeydis = Vector3.Distance(MainCamera.transform.position, MainCameraLocation);
            fj = (Time.deltaTime) * cameraMoveAnimationSpeed / journeydis * 100;
            // Debug.Log(fj);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, MainCameraLocation, fj);

            if (flagMainMenu == 0)
            {
                //MainCamera.transform.rotation = MainCameraRotation;
                cameraPlaceHolder.transform.rotation = new Quaternion(0, 0, 0, 0);
                //Debug.Log("This");

                flagMainMenu = 1;
            }
            if (MainCamera.transform.position == MainCameraLocation || journeydis == 0)
            {
                isBackToMenu = false;
            }
        }
    }
    void gyroCameraController()
    {

        Debug.Log(Input.acceleration);

    }
    private void resetCamera()
    {
        //swipe.enable = true;
        MainCameraAudioListener.enabled = true;
        camera1.SetActive(false);
        audioListenerCamera1.enabled = false;

        camera2.SetActive(false);
        audioListenerCamera2.enabled = false;

        camera3.SetActive(false);
        audioListenerCamera3.enabled = false;
        camera4.SetActive(false);
        audioListenerCamera4.enabled = false;
    }
    private static Quaternion GyroToUnity(Quaternion gyroValues)
    {
        return new Quaternion(gyroValues.x, gyroValues.y, -gyroValues.z, -gyroValues.w);
    }
}