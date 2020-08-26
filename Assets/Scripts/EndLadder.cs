﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLadder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("on");
        if (col.tag == "Player")
        {
            col.GetComponent<playerMovement>().EndOn();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("off");
        if (col.tag == "Player")
        {
            col.GetComponent<playerMovement>().EndOff();
        }
    }
}