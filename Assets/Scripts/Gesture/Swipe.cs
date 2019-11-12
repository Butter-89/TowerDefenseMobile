﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging;
    private Touch touch;
    private Vector2 start, swipeValues, end;
    private Vector3 touchPoi;
    private Vector3 dir;
    public float speed = 10f;

    public GameObject rb;
    void Start()
    {
        
    }

    
    private void Update()
    {

        tap = swipeDown = swipeUp = swipeRight = swipeLeft = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            //tap = true;
            start = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            end = Input.mousePosition;
            if (start == end)
            {
                tap = true;
            }
            isDragging = false;
            Reset();
        }
        #endregion
        #region Mobile Inputs
        if (Input.touchCount > 0)
        {
            Touch touchTest = Input.GetTouch(0);
           if (touchTest.phase == TouchPhase.Moved)
            {
                Vector2 current = touchTest.deltaPosition;
                rb.transform.Rotate(new Vector3(-current.y, -current.x, 0) * Time.deltaTime * speed);
            }
            else if (touchTest.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                rb.transform.Rotate(Vector3.zero);
            }
        }
        #endregion 


        // calculate the swipe distance in pixels
        swipeValues = Vector2.zero;
        if (isDragging)
        {
            if (Input.touchCount > 0)
            {
                swipeValues = Input.touches[0].position - start;
            }
            else if (Input.GetMouseButton(0))
                swipeValues = (Vector2)Input.mousePosition- start;

        }

        //Swipe Detection code
        if (swipeValues.magnitude >150)// 150 is the number of pixels
        {
            float x = swipeValues.x;
            float y = swipeValues.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left or right swipe detection
                if (x > 0)
                    swipeRight = true;
                else
                    swipeLeft = true;
            }
            else
            {
                //Up or down swipe detection
                if (y > 0)
                    swipeUp = true;
                else
                    swipeDown = true;
            }


            Reset();
        }
    }
    private void Reset()
    {
        start = swipeValues = Vector2.zero; // setting both the x and y value to zero;
        isDragging = false;
    }
    public Vector2 SwipeValues { get { return swipeValues; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool Tap { get { return tap; } }
   
    
}
