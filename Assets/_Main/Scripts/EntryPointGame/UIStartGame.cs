using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartGame : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;


    private void Awake()
    {
        HideLoadingScreen();
    }

    public void ShowLoadingScreen()
    {
        loadingScreen.SetActive(true);
    }

    public void HideLoadingScreen()
    {
        loadingScreen.SetActive(false);
    }
}
