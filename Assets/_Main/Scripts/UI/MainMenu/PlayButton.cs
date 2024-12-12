using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;



    [Inject]
    public void Construct(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public void PressPlay()
    {
        this.gameManager.StartWorld();
    }
}
