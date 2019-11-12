﻿using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public TowerSwap towerSwap;
    public Camera_gyro cameraController;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame

    void Update()
    {
       
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                if (raycastHit.transform.parent.gameObject.tag == "Tower" || raycastHit.transform.parent.gameObject.tag == "Tower1" || raycastHit.transform.parent.gameObject.tag == "Tower2" || raycastHit.transform.parent.gameObject.tag == "Tower3")
                {
                    towerSwap.SwapTower(raycastHit.transform.parent.gameObject.transform.localPosition);

                    cameraController.isBackToMenu = false;
                    Transform turrent = raycastHit.transform.parent.Find("Turret Low");
                    cameraController.towerTransform = turrent;
                    cameraController.tagName = raycastHit.transform.parent.tag;
                    Debug.Log(turrent);
                    
                }

                }
            }
        
    }
   
}

