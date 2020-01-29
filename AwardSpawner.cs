using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardSpawner : Spawner
{
    int count = 0;

    protected override void InstantiateObject(Vector3 currentPosition)
    {
        if (count > Constants.awards_per_run)
            gameObject.SetActive(false);

        float rand = Random.value;

        for (int index = 0; index < finalSprites.Length; index++)
        {
            if (rand >= probabilityOfSpawn[index])
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
            }
        }
    }
}    
