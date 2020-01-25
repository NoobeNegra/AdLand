using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectsCollider : MonoBehaviour
{
    ContactPoint2D[] contact;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetContacts(contact);

        Debug.Log("contact.Length " + contact.Length);

        // If the colission is on the side, die
        //if(collision.OverlapPoint())

        //if the collision is on the top, walk over
    }
}
