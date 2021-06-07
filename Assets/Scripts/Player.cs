﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // set variables
    public float jumpSpeed = 2;
    
    // Actual Variables
    public GameObject laneOne;
    public GameObject laneTwo;
    public GameObject laneThree;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = laneOne.transform.position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = laneTwo.transform.position;
        }
    }
}