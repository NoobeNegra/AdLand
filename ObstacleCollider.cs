using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 direction = collision.collider.transform.position - transform.position;

        if (direction.y < 1)
        {
            GameObject character = GameObject.FindGameObjectWithTag("Player");
            character.GetComponent<AdLandCharacterController>().endGame();
        }
    }
}
