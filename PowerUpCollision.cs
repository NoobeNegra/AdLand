using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PowerUpCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        HOTween.To(transform, 2.0f, "localScale", Vector3.zero);
        string key = "Quant" + gameObject.GetComponent<SpriteRenderer>().sprite.name;
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key) + 1);

        Debug.Log("NEW COUNT FOR POWER UP " + PlayerPrefs.GetInt(key));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
