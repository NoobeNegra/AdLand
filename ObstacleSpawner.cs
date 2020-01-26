﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : Spawner
{

    public void askedToSpawn(float xPosition)
    {
        if (xPosition < lastSpawned.x + Constants.tolerated_distance_between_objects || xPosition > lastSpawned.x - Constants.tolerated_distance_between_objects)
            return;

        nextExecution += timeToSpawn;

        toClone.GetComponent<SpriteRenderer>().sprite = spriteAtlas.GetSprite(Constants.forced_object_helper);
        Vector2[] finalColliderPoints = Constants.GetObstaclesColliderPointsByName(Constants.forced_object_helper);
        toClone.GetComponent<EdgeCollider2D>().enabled = true;
        toClone.GetComponent<EdgeCollider2D>().points = finalColliderPoints;
        Vector3 positionToSpawn = Constants.GetPositionToSpawnByName(Constants.forced_object_helper);
        positionToSpawn.x = xPosition;
        lastSpawned = positionToSpawn;
        Destroy(Object.Instantiate(toClone, positionToSpawn, transform.rotation), Constants.time_to_destroy_cloned_object);
    }

    protected override void InstantiateObject(Vector3 currentPosition)
    {
        float rand = Random.value;
        for (int index = 0; index < finalSprites.Length; index++)
        {
            if (rand >= probabilityOfSpawn[index]) 
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                Vector2[] finalColliderPoints = Constants.GetObstaclesColliderPointsByName(finalSprites[index].name);
                if (finalColliderPoints.Length < 2)
                {
                    toClone.GetComponent<EdgeCollider2D>().enabled = false;
                }
                else
                {
                    toClone.GetComponent<EdgeCollider2D>().enabled = true;
                    toClone.GetComponent<EdgeCollider2D>().points = finalColliderPoints;
                }

                Vector3 positionToSpawn = Constants.GetPositionToSpawnByName(finalSprites[index].name);
                currentPosition.z = positionToSpawn.z;
                currentPosition.y = positionToSpawn.y;
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
                break;
            }
        }
    }
}
