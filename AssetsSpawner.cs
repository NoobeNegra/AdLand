using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsSpawner : MonoBehaviour
{
    public GameObject levelAssets;
    public GameObject obstacle;
    public GameObject powerUps;
    public GameObject award;
    public GameObject building;

    public UnityEngine.U2D.SpriteAtlas atlasBuildings;
    public UnityEngine.U2D.SpriteAtlas atlasAwards;
    public UnityEngine.U2D.SpriteAtlas atlasObstacles;
    public UnityEngine.U2D.SpriteAtlas atlasPowerUps;

    [Range(0, 100)]
    public int timeSpawn;

    Vector3 position;
    Sprite[] externalBuildings;
    Sprite[] spritesAwards;
    Sprite[] spritesObstacles;
    Sprite[] spritesPowerUps;
    float nextExecution;

    private void Start()
    {
        position = levelAssets.transform.localPosition;
        externalBuildings = new Sprite[atlasBuildings.spriteCount];
        atlasBuildings.GetSprites(externalBuildings);

        spritesAwards = new Sprite[atlasAwards.spriteCount];
        atlasAwards.GetSprites(spritesAwards);

        spritesObstacles = new Sprite[atlasObstacles.spriteCount];
        atlasObstacles.GetSprites(spritesObstacles);

        spritesPowerUps = new Sprite[atlasPowerUps.spriteCount];
        atlasPowerUps.GetSprites(spritesPowerUps);

        nextExecution = timeSpawn;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localPosition.x % 23.0f >= 22.9f)
        {
            position.x += 53.2f;
            Destroy(Object.Instantiate(levelAssets, position, levelAssets.transform.rotation), 600.0f);
        }

        StartCoroutine("SpawnSomething");
    }

    private void SpawnSomething()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        //int typeOfSpawn = Random.Range(0, 3);
        float distance = Random.Range(25.0f, 60.0f);
        //float height = Random.Range(-2.5f, 3.0f);
        int texture = 0;
        Vector3 currentPosition = transform.localPosition;
        currentPosition.x += distance;
        //switch (typeOfSpawn)
        {
            /*case 0: //Spawn a building
                currentPosition.z = 25.0f;
                //Set a random texture
                texture = Random.Range(0, externalBuildings.Length - 1);
                building.GetComponent<SpriteRenderer>().sprite = externalBuildings[texture];
                Destroy(Object.Instantiate(building, currentPosition, building.transform.rotation), 600.0f);
                break;*/
            //case 1: //Spawn an award
                currentPosition.z = 1.0f;
                //currentPosition.y += height;
                currentPosition.y = -3.0f;
                texture = Random.Range(0, spritesAwards.Length - 1);
                award.GetComponent<SpriteRenderer>().sprite = spritesAwards[texture];
                Destroy(Object.Instantiate(award, currentPosition, award.transform.rotation), 600.0f);
                //break;
            /*case 2: //Spawn a powerup
                currentPosition.z = 1.0f;
                currentPosition.y += height;
                texture = Random.Range(0, spritesPowerUps.Length - 1);
                powerUps.GetComponent<SpriteRenderer>().sprite = spritesPowerUps[texture];
                Destroy(Object.Instantiate(powerUps, currentPosition, powerUps.transform.rotation), 600.0f);
                break;
            case 3: //Spawn an obstacle
                currentPosition.z = 1.0f;
                texture = Random.Range(0, spritesObstacles.Length - 1);
                obstacle.GetComponent<SpriteRenderer>().sprite = spritesObstacles[texture];
                Destroy(Object.Instantiate(obstacle, currentPosition, obstacle.transform.rotation), 600.0f);
                break;*/
        }

        nextExecution += timeSpawn;
    }
}
