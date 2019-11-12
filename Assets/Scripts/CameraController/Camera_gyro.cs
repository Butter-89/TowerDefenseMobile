﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_gyro : MonoBehaviour
{
    public TouchDetection touch;
    public SwipeDetection swipe;

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
    //debug

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

    AudioListener MainCameraAudioListener;
    AudioListener audioListenerCamera1;
    AudioListener audioListenerCamera2;
    AudioListener audioListenerCamera3;
    float fj;
    int n = 0;
   public bool isBackToMenu= false;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
        moveCamera();
        BackToMenu();
        Debug.Log(isBackToMenu);
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
            yRot = Mathf.Clamp( Input.acceleration.x ,-0.35f, 0.3f)* 180f;
            zRot = 0f;
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, Quaternion.Euler(new Vector3(xRot, yRot * 1.1f, zRot)), Time.deltaTime * sensitivity);



            //Code to move the camera to the selected tower
            journeydis = Vector3.Distance(MainCamera.transform.position, movePosition);
          //  Debug.Log(journeydis);
             fj = (Time.deltaTime) * cameraMoveAnimationSpeed / journeydis*100 ;
            //Debug.Log(journeydis);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, movePosition, fj);


            //{
            //    swipe.isTouchEnabled = false;
            //   // MainCamera.SetActive(false);
            //    MainCameraAudioListener.enabled = false;

            //    towerTransform.rotation = camera.transform.rotation;

            //    camera1.SetActive(true);
            //    audioListenerCamera1.enabled = true;

            //    camera = camera1.GetComponent<Camera>();


            //}
            if (journeydis==0 || MainCamera.transform.position == movePosition)
            {
                
                swipe.isTouchEnabled = false;
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

    public void ButtonClick()
    {
        isBackToMenu = true;
        isMoveCamera = false;
        journeydis = 0;
        
        n = 0;
    }
    private void BackToMenu()
    {
        //Debug.Log("clicked" + isBackToMenu);
        if (isBackToMenu == true)
        {

            swipe.isTouchEnabled = true;
            MainCameraAudioListener.enabled = true;
            camera1.SetActive(false);
            audioListenerCamera1.enabled = false;

            camera2.SetActive(false);
            audioListenerCamera2.enabled = false;

            camera3.SetActive(false);
            audioListenerCamera3.enabled = false;
            //camera = MainCamera.GetComponent<Camera>();
            
            journeydis = Vector3.Distance(MainCamera.transform.position, MainCameraLocation);
             fj = (Time.deltaTime) * cameraMoveAnimationSpeed / journeydis *100;
           // Debug.Log(fj);
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, MainCameraLocation, fj);
            if (n == 0)
            {
                MainCamera.transform.rotation = MainCameraRotation;
                
                n = 1;
            }
            if (MainCamera.transform.position == MainCameraLocation)
            {
                isBackToMenu = false;
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