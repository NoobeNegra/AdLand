using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Make the object dissapear
        transform.DOScale(Vector3.zero, Constants.time_to_complete_tween);

        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<AdLandCharacterController>().isUnderTheinfluence(Constants.GetValueOfInfluence(gameObject.GetComponent<SpriteRenderer>().sprite.name));
    }
}
