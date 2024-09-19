using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    //[SerializeField] private World currentWorld;
    private GameState previusGameState;
    private GameState currentGameState;
    //event change Game state action


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
    private void Start()
    {
        // ������������� �� ������� �������� �����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void ChangeGameState(GameState newGameState)
    {
        currentGameState = newGameState;
        switch (currentGameState)
        {
            case GameState.Menu:
                SendEventChangeState(currentGameState);
                break;

            case GameState.Boot:
                SendEventChangeState(currentGameState);
                break;

            case GameState.Gameplay:
                SendEventChangeState(currentGameState);
                break;

            default:
                break;
        }
    }

    private void SendEventChangeState(GameState newState)
    {
        previusGameState = currentGameState;
        currentGameState = newState;
        EventBus.RaiseEvent(new NewGameStateEvent(previusGameState, currentGameState));
    }

    public void StartWorld()
    {
        SceneManager.LoadSceneAsync(Scenes.GAMEPLAY);
        ChangeGameState(GameState.Gameplay);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Play")
        {
            // ������� ��������� ������� currentWorld �� ����� "Play"
            //GameObject worldObject = Instantiate(currentWorld.gameObject, Vector3.zero, Quaternion.identity);
            // �������� ����� Start() � ���������� �������
            //worldObject.GetComponent<World>().Start();
        }
    }
}

