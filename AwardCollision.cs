using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        transform.DOScale(Vector3.zero, Constants.time_to_complete_tween);

        int amountToAdd = Constants.GetValueOfAward(gameObject.GetComponent<SpriteRenderer>().sprite.name);
        string key = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key) + amountToAdd);
        PlayerPrefs.Save();
    }
}
