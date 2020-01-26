using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public UnityEngine.UI.Text coins;
    public UnityEngine.UI.Text dieText;
    public UnityEngine.UI.Text quillCount;
    public UnityEngine.UI.Text kittyCount;
    public UnityEngine.UI.Text finalCoinCount;

    public UnityEngine.UI.Text homeText;

    public UnityEngine.UI.Image quillImage;
    public UnityEngine.UI.Image kittyImage;
    public UnityEngine.UI.Image dollarImage;

    
    // Start is called before the first frame update
    void Start()
    {
        UpdateCoinsAmount();
        dieText.text = "";
        quillCount.enabled = false;
        kittyCount.enabled = false;
        finalCoinCount.enabled = false;
        homeText.enabled = false;

        quillImage.enabled = false;
        kittyImage.enabled = false;
        dollarImage.enabled = false;
    }

    void UpdateCoinsAmount()
    {
        coins.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    void SendDieText()
    {
        dieText.text = "WE SELL OR WE DIE";
        UpdateAwardsAmount();
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateAwardsAmount()
    {
        quillCount.enabled = true;
        kittyCount.enabled = true;
        finalCoinCount.enabled = true;

        quillImage.enabled = true;
        kittyImage.enabled = true;
        dollarImage.enabled = true;
        homeText.enabled = true;

        quillCount.text = PlayerPrefs.GetInt("QuillCount").ToString();
        kittyCount.text = PlayerPrefs.GetInt("KittyCount").ToString();
        finalCoinCount.text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
