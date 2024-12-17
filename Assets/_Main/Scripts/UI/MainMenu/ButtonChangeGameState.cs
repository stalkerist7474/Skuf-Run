using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ButtonChangeGameState : MonoBehaviour
{

    [SerializeField] private GameState gameStateButton;
    [SerializeField] private GameManager gameManager;

    [Inject]
    public void Construct(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }


    public void ChangeGameState()
    {
        Debug.Log($"gameManager = {gameManager.name}----gameStateButton={gameStateButton}");
        EventBus.RaiseEvent(new NewGameStateEvent(gameManager.CurrentGameState, gameStateButton));
        Debug.Log("ChangeGameState Button press");
    }
}
