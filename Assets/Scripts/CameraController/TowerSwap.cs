using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSwap : MonoBehaviour
{
  
    public Camera_gyro cameraController;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 
    /// </summary>
    public void SwapTower(Vector3 selectedTower)
    {

        //towerNetworkManager.GoToNext();
        Vector3 offset = new Vector3(0f,selectedTower.y + 7f,5f);
     //   Debug.Log(current.transform.position);

        cameraController.isMoveCamera = true;
        cameraController.movePosition = selectedTower+ offset;
        //StartCoroutine(moveCameraAnimation(current.transform.position));




    }
 
}
