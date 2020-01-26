using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class PowerUpCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        HOTween.To(transform, Constants.time_to_complete_tween, "localScale", Vector3.zero);

        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<AdLandCharacterController>().isUnderTheinfluence(Constants.GetValueOfInfluence(gameObject.GetComponent<SpriteRenderer>().sprite.name));
    }
}
