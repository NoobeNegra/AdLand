using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : Spawner
{
    public ObstacleSpawner help;
    public bool variateHeight;

    protected override void InstantiateObject(Vector3 currentPosition)
    {
        if (variateHeight)
        {
            float height = Random.Range(Constants.min_height_value, Constants.max_height_value);
            currentPosition.y += height;

            // if it's higher that my higest jump, ask for an obstacle to help
            if (height > Constants.jump_endTriggerHeights[0])
            {
                help.askedToSpawn(currentPosition.x);
            }
        }

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
