using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TocuhDetection : MonoBehaviour 
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "myGameObjectName")
            {
                hit.GetComponent<TouchObjectScript>().ApplyForce();
            }
        }

    }
    public void ApplyForce()
    {

        Debug.Log("Touch Occured");
    }
}
