using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using R3;

public class GameManager : MonoBehaviour, IEventSubscriber<NewGameStateEvent>
{

    public static GameManager Instance;
    private GameState previusGameState = GameState.Boot;
    private GameState currentGameState;

    public GameState CurrentGameState { get => currentGameState; }

    //Unirx
    //public readonly Subject<GameState> NewGameStateEventRx = new Subject<GameState>();



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Subscribe()
    {
        EventBus.RegisterTo(this as IEventSubscriber<NewGameStateEvent>);
    }
    public void Unsubscribe()
    {
        EventBus.UnregisterFrom(this as IEventSubscriber<NewGameStateEvent>);
    }
    public void OnEvent(NewGameStateEvent eventName)
    {
        ChangeGameState(eventName.NewState);
    }
    private void Start()
    {
        Subscribe();
    }

    //обработка нового GameState и выполнение необходимых методов
    private void ChangeGameState(GameState newGameState)
    {
        previusGameState = currentGameState;
        currentGameState = newGameState;

        switch (currentGameState)
        {
            case GameState.Menu:
                StartMainMenu();
                break;

            case GameState.Boot:
                //
                break;

            case GameState.Gameplay:
                StartGamePlay();
                break;

            default:
                break;
        }
    }

    private void StartGamePlay()
    {
        SceneManager.LoadSceneAsync(Scenes.GAMEPLAY);
    }

    private void StartMainMenu()
    {
        SceneManager.LoadSceneAsync(Scenes.MENU);
    }

    public void ChangeGameStateWithoutLoadScene(GameState newGameState)
    {
        previusGameState = currentGameState;
        currentGameState = newGameState;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}

