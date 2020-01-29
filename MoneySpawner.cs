﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : Spawner
{
    protected override void InstantiateObject(Vector3 currentPosition)
    {
        float rand = Random.value;

        if (rand >= 0.5f)
        {
            int numberToSpawn = Random.Range(1, Constants.max_amoun_dolla_bills);

            for (int n = 0; n < numberToSpawn; n++)
            {
                currentPosition.x += Constants.max_distance_between_dolla_bills;
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
            }
        }
    }
}    
