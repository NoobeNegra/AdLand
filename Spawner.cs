using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public UnityEngine.U2D.SpriteAtlas spriteAtlas;
    public int timeToSpawn;
    public bool variateHeight;
    public bool affectedByDaylight;
    public Camera mainCamera;
    public GameObject toClone;
    public ObstacleSpawner help;

    protected float[] probabilityOfSpawn;
    protected Sprite[] finalSprites;
    protected float nextExecution;
    protected Vector3 lastSpawned;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        finalSprites = new Sprite[spriteAtlas.spriteCount];
        probabilityOfSpawn = new float[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(finalSprites);
        for(int i = 0; i < probabilityOfSpawn.Length; i++){
            probabilityOfSpawn[i] = Constants.GetProbabilityByName(finalSprites[i].name);
        }
        nextExecution = timeToSpawn;
        lastSpawned = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        nextExecution += timeToSpawn;
        StartCoroutine("SpawnNow");
    }

    public void SpawnNow()
    {
        if (lastSpawned == Vector3.zero)
        {
            lastSpawned = mainCamera.transform.localPosition;
        }

        float distance = Random.Range(Constants.min_distance_object_spawn, Constants.max_distance_object_spawn);

        Vector3 currentPosition = mainCamera.transform.localPosition;
        currentPosition.x = lastSpawned.x + distance;
        currentPosition.z = Constants.z_value_character;
        lastSpawned = currentPosition;
        if (variateHeight)
        {
            float height = Random.Range(Constants.min_height_value, Constants.max_height_value);
            currentPosition.y += height;

            // if it's higher that my higest jump, ask for an obstacle to help
            if (height > Constants.jump_endTriggerHeights[Constants.jump_endTriggerHeights.Length - 1])
            {
                help.askedToSpawn(currentPosition.x);
            }
        }

        InstantiateObject(currentPosition);
    }
    
    protected virtual void InstantiateObject(Vector3 currentPosition)
    {
        float rand = Random.value;
        for (int index = 0; index < finalSprites.Length; index++)
        {
            if (rand >= probabilityOfSpawn[index]) // rand = 0.21 and value = 0.2 (meaning 80% probs) it will be spawn this type of object
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
                break;
            }
        }
    }
}
