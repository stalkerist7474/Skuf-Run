using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateChangerOnStartScene : MonoBehaviour
{
    [SerializeField] private GameState gameStateToOn;
    [SerializeField] private GameManager gameManager;
    private void Start()
    {
        ChangeGameState();
    }

    [Inject]
    public void Construct(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public void ChangeGameState()
    {
        gameManager.ChangeGameStateWithoutLoadScene(gameStateToOn);
    }

}
