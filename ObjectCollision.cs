using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision biatch");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter on trigger biatch");
    }
}
