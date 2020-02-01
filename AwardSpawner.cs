using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardSpawner : Spawner
{
    public ObstacleSpawner help;
    public bool variateHeight;
    
    private int count = 0;
    
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
        base.InstantiateObject(currentPosition);
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        nextExecution += timeToSpawn;

        // Recalculate a possibility to spawn an award
        float rand = Random.value;
        if (rand >= Constants.possibility_of_award_spawn && count < Constants.awards_per_run){
            count++;
            StartCoroutine("SpawnNow");
        }
        else if (count >= Constants.awards_per_run){
            Destroy(gameObject, Constants.seconds_to_destroy_gameobject);
        }      
    }
}    
