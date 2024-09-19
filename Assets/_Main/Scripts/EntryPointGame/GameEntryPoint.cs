using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint: MonoBehaviour
{
    private static GameEntryPoint instance;
    [SerializeField] private UIStartGame UIStartGame;
    [SerializeField] private List<IGameSystem> gameSystems;


    private void Awake()
    {
        
    }

    private IEnumerator Start()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        UIStartGame.ShowLoadingScreen();


        foreach (var system in gameSystems)
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        //savemanager

        //firebase

        //adMob
        yield return SceneManager.LoadSceneAsync(Scenes.MENU);
        

    }



    

}
