using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsSpawner : Spawner
{
    protected override void InstantiateObject(Vector3 currentPosition)
    {
        float rand = Random.value;
        for (int index = 0; index < finalSprites.Length; index++)
        {
            if (rand >= probabilityOfSpawn[index]) 
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                Vector3 positionToSpawn = Constants.GetPositionToSpawnByName(finalSprites[index].name);
                currentPosition.z = positionToSpawn.z;
                currentPosition.y = positionToSpawn.y;
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
                break;
            }
        }
    }
}
