using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public UnityEngine.U2D.SpriteAtlas spriteAtlas;
    public float timeToSpawn;
    public Camera mainCamera;
    public GameObject toClone;

    protected float[] probabilityOfSpawn;
    protected Sprite[] finalSprites;
    protected float nextExecution;
    protected Vector3 lastSpawned;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameObject.SetActive(true);

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
    protected virtual void FixedUpdate()
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
