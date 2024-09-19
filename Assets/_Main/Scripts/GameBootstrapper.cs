using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen; // ����� � ����������� ��������
    [SerializeField] private List<IGameSystem> gameSystems; // ������ ������ ����

    private void Awake()
    {
        // �������� ����� � ����������� ��������, ���� ���� ��������
        loadingScreen.SetActive(false);

        // ��������� �������� ������ ����
        StartCoroutine(InitializeGameSystems());
    }

    private IEnumerator InitializeGameSystems()
    {
        // ���������� ����� � ����������� ��������
        loadingScreen.SetActive(true);

        // ��������� ������� ���� �� �������
        foreach (var system in gameSystems)
        {
            system.Activate();
            Debug.Log($"<color=#20C30C>Load System = {system.gameObject.name}</color>");
        }

        // ����� ���������� �������� ������ 
        // ��������� �������� ������� �����
        yield return SceneManager.LoadSceneAsync("Menu");

        // �������� ����� � ����������� ��������
        loadingScreen.SetActive(false);
    }
}
