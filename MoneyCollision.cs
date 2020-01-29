using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        transform.DOScale(Vector3.zero, Constants.time_to_complete_tween);

        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + Constants.value_of_dollar_bill);
        PlayerPrefs.Save();

        //Update the UI
        GameObject.Find("Canvas").SendMessage("UpdateCoinsAmount");
    }
}
