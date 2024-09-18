using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEntryPoint
{
    private static GameEntryPoint instance;
    private CorutineSourse corutineSourse;
    private UIStartGame UIStartGame;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void AutoStartGame()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        instance = new GameEntryPoint();
        instance.RunGame();
    }

    private GameEntryPoint() 
    {
        //корутинаас монобехом
        corutineSourse = new GameObject("EntryCorutines").AddComponent<CorutineSourse>();  
        Object.DontDestroyOnLoad(corutineSourse.gameObject);

        var prefabUILoadingScreen = Resources.Load<UIStartGame>("UIStartGame");
        UIStartGame = Object.Instantiate(prefabUILoadingScreen);
        Object.DontDestroyOnLoad(UIStartGame.gameObject);

    }




    private void RunGame()
    {

#if UNITY_EDITOR

        var sceneName = SceneManager.GetActiveScene().name; 

        if (sceneName == Scenes.GAMEPLAY)
        {
            corutineSourse.StartCoroutine(LoadAndStartGameplay());
            return;
        }

        if (sceneName == Scenes.MENU)
        {

            return;
        }

        if (sceneName == Scenes.BOOT)
        {

            return;
        }


#endif
        corutineSourse.StartCoroutine(LoadAndStartGameplay());

    }


    private IEnumerator LoadAndStartGameplay()
    {
        UIStartGame.ShowLoadingScreen();

        yield return LoadScene(Scenes.BOOT);
        yield return LoadScene(Scenes.GAMEPLAY);

        UIStartGame.HideLoadingScreen();
    }

    private IEnumerator LoadScene(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
    }

}
