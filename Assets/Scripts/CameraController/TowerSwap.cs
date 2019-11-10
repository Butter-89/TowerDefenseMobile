using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSwap : MonoBehaviour
{
    public TowerNetworkManager towerNetworkManager;
    public Camera_gyro cameraController;
    GameObject current;
    private float journeydis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Go to the next tower;
    /// </summary>
    public void SwapTower()
    {
        
        towerNetworkManager.GoToNext();
      current =  towerNetworkManager.CurrentTower;
        Debug.Log(current.transform.position);

        cameraController.isMoveCamera = true;
        cameraController.movePosition = current.transform.position;
        //StartCoroutine(moveCameraAnimation(current.transform.position));




    }
 
}
