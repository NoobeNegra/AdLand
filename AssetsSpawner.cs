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

    public Texture2D[] awards;
    public Texture2D[] obstacles;
    public UnityEngine.U2D.SpriteAtlas atlas;

    [Range(0, 5)]
    public int timeSpawn;

    Vector3 position;
    Sprite[] externalBuildings;

    private void Start()
    {
        position = levelAssets.transform.localPosition;
        externalBuildings = new Sprite[atlas.spriteCount];
        atlas.GetSprites(externalBuildings);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("X " + transform.localPosition.x);
        if (transform.localPosition.x % 23.0f >= 22.9f)
        {
            position.x += 53.2f;
            Destroy(Object.Instantiate(levelAssets, position, levelAssets.transform.rotation), 600.0f);
        }

        if (Time.realtimeSinceStartup % timeSpawn <= 0.5f)
        {
            int typeOfSpawn = Random.Range(0, 3);
            float distance  = Random.Range(25.0f, 60.0f);
            float height    = Random.Range(-2.5f, 3.0f);

            Vector3 currentPosition = transform.localPosition;
            currentPosition.x += distance;
            switch (typeOfSpawn)
            {
                case 0: //Spawn a building
                    currentPosition.z = 25.0f;
                    //Set a random texture
                    int buildingTexture = Random.Range(0, externalBuildings.Length - 1);
                    building.GetComponent<SpriteRenderer>().sprite = externalBuildings[buildingTexture];
                    Destroy(Object.Instantiate(building, currentPosition, building.transform.rotation), 600.0f);
                break;
                case 1: //Spawn an award
                    currentPosition.z = 2.0f;
                    currentPosition.y += height;
                    Destroy(Object.Instantiate(award, currentPosition, award.transform.rotation), 600.0f);
                break;
                case 2: //Spawn a powerup
                    currentPosition.z = 2.0f;
                    currentPosition.y += height;
                    Destroy(Object.Instantiate(powerUps, currentPosition, powerUps.transform.rotation), 600.0f);
                break;
                case 3: //Spawn an obstacle
                    currentPosition.z = 2.0f;
                    Destroy(Object.Instantiate(obstacle, currentPosition, obstacle.transform.rotation), 600.0f);
                break;
            }
        }
    }
}
