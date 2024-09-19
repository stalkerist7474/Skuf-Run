using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen; // Сцена с индикатором загрузки
    [SerializeField] private List<IGameSystem> gameSystems; // Список систем игры

    private void Awake()
    {
        // Скрываем сцену с индикатором загрузки, пока идет загрузка
        loadingScreen.SetActive(false);

        // Запускаем загрузку систем игры
        StartCoroutine(InitializeGameSystems());
    }

    private IEnumerator InitializeGameSystems()
    {
        // Отображаем сцену с индикатором загрузки
        loadingScreen.SetActive(true);

        // Загружаем системы игры по очереди
        foreach (var system in gameSystems)
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        // После завершения загрузки систем 
        // загружаем основную игровую сцену
        yield return SceneManager.LoadSceneAsync("Menu");

        // Скрываем сцену с индикатором загрузки
        loadingScreen.SetActive(false);
    }
}
