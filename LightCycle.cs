using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycle : MonoBehaviour
{
    public float duration;
    float daysCount = 0;

    void FixedUpdate()
    {

        transform.RotateAround(Vector3.zero, Vector3.right, 360.0f * (Time.deltaTime / duration));
        transform.LookAt(Vector3.zero);

        if (transform.worldToLocalMatrix.m11 == 1)
        {
            daysCount += 0.5f;
        }
    }
}
