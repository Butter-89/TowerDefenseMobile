using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public TowerSwap towerSwap;


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
                towerSwap.SwapTower(raycastHit.transform.parent.gameObject.transform.localPosition);
                Transform Camera = raycastHit.transform.parent.Find("Camera");
                Debug.Log(Camera) ;
                
            }
        }
    }
   
}

