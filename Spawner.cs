using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public UnityEngine.U2D.SpriteAtlas spriteAtlas;
    public int timeToSpawn;
    public bool variateHeight;
    public Camera mainCamera;
    public GameObject toClone;

    [Range(0, 1)]
    public float[] probabilityOfSpawn;

    Sprite[] finalSprites;
    float nextExecution;


    // Start is called before the first frame update
    void Start()
    {
        finalSprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(finalSprites);
        nextExecution = timeToSpawn;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        nextExecution += timeToSpawn;
        //Debug.Log("Next Execution " + nextExecution + " Time "+ Time.realtimeSinceStartup);
        //Debug.Break();
        StartCoroutine("SpawnNow");
    }

    private void SpawnNow()
    {
        //Debug.Log("Enters in coroutine");
        //Debug.Break();

        float distance = Random.Range(25.0f, 60.0f);
        float rand = Random.value;
        Vector3 currentPosition = mainCamera.transform.localPosition;
        currentPosition.x += distance;
        currentPosition.z = 1.0f;
        if (variateHeight)
        {
            float height = Random.Range(-2.5f, 3.0f);
            currentPosition.y += height;
        }

        for (int index = 0; index < finalSprites.Length; index++)
        {
            //Debug.Log("In for " + index + " loop random value " + rand + " probability " + probabilityOfSpawn[index]);
            //Debug.Break();
            if (rand >= probabilityOfSpawn[index]) // rand = 0.21 and value = 0.2 (meaning 80% probs) it will be spawn this type of object
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), 600.0f);
                break;
            }
        }
        //Debug.Log("End of it");
        //Debug.Break();
    }
}
