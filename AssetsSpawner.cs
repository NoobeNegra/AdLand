using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsSpawner : MonoBehaviour
{
    public GameObject levelAssets;
    Vector3 position;

    private void Start()
    {
        position = levelAssets.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localPosition.x % 23.0f >= 22.9f)
        {
            position.x += 53.2f;
            var clone = Object.Instantiate(levelAssets, position, levelAssets.transform.rotation);
            Destroy(clone, 20.0f);
        }
    }
}
