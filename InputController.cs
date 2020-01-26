using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    public string method;

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(method);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Passing by");
    }

    public void LaunchGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
