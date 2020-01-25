using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class ObjectCollision : MonoBehaviour
{
    public bool animate;
    public int quillValue;
    public int goldenKittenValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animate)
        {
            // Make the object dissapear
            HOTween.To(transform, 2.0f, "localScale", Vector3.zero);

            if (gameObject.tag == "Awards" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "quill")
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + quillValue);
            }
            else if (gameObject.tag == "Awards" && gameObject.GetComponent<SpriteRenderer>().sprite.name == "golden_kitten")
            {
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + goldenKittenValue);
            }
            else if (gameObject.tag == "Powerups")
            {
                //TODO develop this
                Debug.Log(" A poiwer up has been taken ");
            }
        }
        else // It is the end of the game
        {
            //Debug.Break();
            Debug.Log(" TIME TO DIE !!! ");
        }
    }
}
