using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class AwardCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        HOTween.To(transform, Constants.time_to_complete_tween, "localScale", Vector3.zero);

        int amountToAdd = Constants.GetValueOfAward(gameObject.GetComponent<SpriteRenderer>().sprite.name);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + amountToAdd);
        PlayerPrefs.Save();

        //Update the UI
        GameObject.Find("Canvas").SendMessage("UpdateCoinsAmount");
    }
}
