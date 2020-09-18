﻿using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class AddMoneyTest : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    public void AddMoney()
    {
        playerStats.money += 100;
    } 
}
