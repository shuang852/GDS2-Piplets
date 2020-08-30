﻿using System;
using System.Collections;
using System.Collections.Generic;
using Farming;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlantFunctions))]
public class FarmPlot : MonoBehaviour
{
    [SerializeField] private PlantSeed currentPlantType;

    private PlantFunctions _currentPlant;
    

    /*public FarmPlot(Plant currentPlant)
    {
        _currentPlant = currentPlant;
    }*/

    // Start is called before the first frame update
    private void Start()
    {
        _currentPlant = GetComponent<PlantFunctions>();
        if (currentPlantType != null)
        {
            OnPlant(currentPlantType);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            OnPlant(currentPlantType);
        }*/
    }

    // Interacting with bare hands/no items in hands
    public void InteractBare(Player player)
    {
        if (_currentPlant.IsPlanted())
        {
            _currentPlant.OnInteract(player);
        }
    }

    //Interacting with item in hand/use
    public void InteractWithItem(Item item, Player player)
    {
        // Watering can waters plants
        if (item.name == "Watering Can")
        {
            _currentPlant.OnWatered();
        }
        
        //If it's a seed it'll plant if it's empty
        else if (item as PlantSeed)
        {
            // If plant is empty and player has room
            if (!_currentPlant.IsPlanted()  && player.inventory.RemoveItem(item))
            {
                OnPlant(item as PlantSeed);
            }
        }
    }

    // Plants the plant
    private void OnPlant(PlantSeed plantSeed)
    {
        _currentPlant.Plant(plantSeed);
        currentPlantType = plantSeed;
        //Add grow to day pass delegate
        // delegate += DaysPassed();
        // Or subscribe object to days passing script
    }
    
    public void OnDestroyCrop()
    {
        _currentPlant.DestroyPlant();
    }

    public void OnSeasonEnd()
    {
        _currentPlant.OnSeasonEnd();
    }
}