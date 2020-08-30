﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class Piplet : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private float stoppingDistance = 3;
    public int level; 
    [SerializeField] private int steps = 0;
    [SerializeField] private int level2Threshold = 300;
    [SerializeField] private int level3Threshold = 3000;
    public Player player;
    private Transform target;
    private bool stepping;
    private playerMovement _PlayerMovement;

    void Start()
    {
        target = player.transform;
        level = 1;
        _PlayerMovement = player.GetComponent<playerMovement>();
    }


    void Update()
    {
        if (_PlayerMovement.GroundCheck == true && target.transform.position.y == transform.position.y)
        {
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (!stepping)
                {
                    StartCoroutine(BuildTrust());
                }
            }

        }
        else if (_PlayerMovement.GroundCheck == true && target.transform.position.y != transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y,transform.position.z);
        }

        if (steps > level2Threshold)
        {
            level = 2;
        }

        if (steps > level3Threshold)
        {
            level = 3;
        }
    }

   private IEnumerator BuildTrust()
    {
        steps += 1;
        stepping = true;
        yield return new WaitForSeconds(1);
        stepping = false;
    }
}