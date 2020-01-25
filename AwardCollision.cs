using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class AwardCollision : MonoBehaviour
{
    Dictionary<string,int> rewardsValue;

    private void Awake()
    {
        rewardsValue = new Dictionary<string, int>();
        rewardsValue.Add("quill(Clone)", 10);   
        rewardsValue.Add("golden_kitten(Clone)", 30);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        HOTween.To(transform, 2.0f, "localScale", Vector3.zero);
        int amountToAdd = 0;
        Debug.Log("sprite name " + gameObject.GetComponent<SpriteRenderer>().sprite.name);
        rewardsValue.TryGetValue(gameObject.GetComponent<SpriteRenderer>().sprite.name, out amountToAdd);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + amountToAdd);

        //Debug.Log("NEW COIN COUNT " + PlayerPrefs.GetInt("Coins"));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
