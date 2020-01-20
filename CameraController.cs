using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform characterTransform; //This must be set in inspector manually
    //Manually set the offset
    [Range(-6f, 6f)]
    public float xOffset;
    [Range(-6f, 6f)]
    public float yOffset;

    private Vector3 finalCameraPosition;

    // Update is called once per frame
    void Update()
    {
        //This update prevents the creation of new Vector3 every frame.
        finalCameraPosition.x = characterTransform.position.x + xOffset;

        transform.position = finalCameraPosition;
    }
}
