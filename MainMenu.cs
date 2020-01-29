using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Texture background;
    bool touched;

    private void Awake()
    {
        touched = false;
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
    }

    private void Update()
    {
        if (!touched)
        {
            if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                touched = true;
                SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            }
        }
    }
}
