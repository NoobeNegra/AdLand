using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsSpawner : MonoBehaviour
{


    public GameObject obstacle;
    public GameObject powerUps;
    public GameObject building;

    public UnityEngine.U2D.SpriteAtlas atlasBuildings;
    public UnityEngine.U2D.SpriteAtlas atlasObstacles;
    public UnityEngine.U2D.SpriteAtlas atlasPowerUps;

    [Range(0, 1)]
    public float probabilityOfGoldenKitten;

    [Range(0, 100)]
    public int timeSpawn;

    Sprite[] externalBuildings;
    Sprite[] spritesObstacles;
    Sprite[] spritesPowerUps;
    float nextExecution;
    

    private void Start()
    {
        externalBuildings = new Sprite[atlasBuildings.spriteCount];
        atlasBuildings.GetSprites(externalBuildings);
        
        spritesObstacles = new Sprite[atlasObstacles.spriteCount];
        atlasObstacles.GetSprites(spritesObstacles);

        spritesPowerUps = new Sprite[atlasPowerUps.spriteCount];
        atlasPowerUps.GetSprites(spritesPowerUps);

        nextExecution = timeSpawn;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine("SpawnSomething");
    }

    private void SpawnSomething()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        //float typeOfSpawn = Random.value;
        int typeOfSpawn = Random.Range(0,4);
        float distance = Random.Range(25.0f, 60.0f);
        float height = Random.Range(-2.5f, 3.0f);
        int texture = 0;
        float rand;
        Vector3 currentPosition = transform.localPosition;
        currentPosition.x += distance;
        switch (typeOfSpawn)
        {
            case 0: //Spawn a building
                currentPosition.z = 25.0f;
                //Set a random texture
                texture = Random.Range(0, externalBuildings.Length - 1);
                building.GetComponent<SpriteRenderer>().sprite = externalBuildings[texture];
                Destroy(Object.Instantiate(building, currentPosition, building.transform.rotation), 600.0f);
            break;
            case 3: //Spawn an obstacle
                currentPosition.z = 1.0f;
                texture = Random.Range(0, spritesObstacles.Length - 1);
                obstacle.GetComponent<SpriteRenderer>().sprite = spritesObstacles[texture];
                Destroy(Object.Instantiate(obstacle, currentPosition, obstacle.transform.rotation), 600.0f);
            break;
        }

        nextExecution += timeSpawn;
    }
}
