using System;
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

    public GameObject levelAssets;

    private Vector3 finalCameraPosition;

    Vector3 position;

    private void Start()
    {
        position = levelAssets.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //This update prevents the creation of new Vector3 every frame.
        finalCameraPosition.x = characterTransform.position.x + xOffset;
        transform.position = finalCameraPosition;

        // Spawn more background
        if (transform.localPosition.x % 23.0f >= 22.9f)
        {
            position.x += 53.2f;
            Destroy(UnityEngine.Object.Instantiate(levelAssets, position, levelAssets.transform.rotation), 600.0f);
        }
    }
}
