using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    public ObstacleSpawner help;
    public bool variateHeight;
    public LightCycle lightCycle;

    Sprite[] dayLightSprites;
    Sprite[] dayNightSprites;

    float[] probsForDay;
    float[] probsForNight;

    protected override void Start(){
        base.Start();
        dayLightSprites = new Sprite[]{spriteAtlas.GetSprite("triple_shot_macchiato"), spriteAtlas.GetSprite("coffee")};
        dayNightSprites = new Sprite[]{spriteAtlas.GetSprite("instant_energy")};
        
        probsForDay = new float[dayLightSprites.Length];
        probsForNight = new float[dayNightSprites.Length];

        for (int i = 0; i < dayLightSprites.Length; i++){
            probsForDay[i] = Constants.GetProbabilityByName(dayLightSprites[i].name);
        }
        for (int i = 0; i < dayNightSprites.Length; i++){
            probsForNight[i] = Constants.GetProbabilityByName(dayNightSprites[i].name);
        }
    }

    protected override void InstantiateObject(Vector3 currentPosition)
    {
        float rand = Random.value;
        if (lightCycle.isDayTime){
            for (int index = 0; index < dayLightSprites.Length; index++)
            {
                if (rand >= probsForDay[index]) 
                {
                    toClone.GetComponent<SpriteRenderer>().sprite = dayLightSprites[index];
                    Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
                    break;
                }
            }
        }else{
            for (int index = 0; index < dayNightSprites.Length; index++)
            {
                if (rand >= probsForNight[index]) 
                {
                    toClone.GetComponent<SpriteRenderer>().sprite = dayNightSprites[index];
                    Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), Constants.time_to_destroy_cloned_object);
                    break;
                }
            }
        }       
    }
}    
