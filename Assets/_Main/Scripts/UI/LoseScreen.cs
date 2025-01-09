using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Zenject;
using TMPro;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup CanvasGroup;
    [SerializeField] private TMP_Text scoreText;


    private PlayerModel playerModel;
    private CompositeDisposable disposable = new CompositeDisposable();


    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        this.playerModel = playerModel;
        Debug.Log("Construct");
    }

    private void Awake()
    {
        playerModel.ShowLoseScreen
            .Subscribe(currentScore => Show(currentScore))
            .AddTo(disposable);

        Hide();
    }

    private void Show(int scoreValue)
    {
        CanvasGroup.alpha = 1;
        CanvasGroup.interactable = true;
        CanvasGroup.blocksRaycasts = true;

        scoreText.text = scoreValue.ToString();
    }

    public void Hide()
    {
        CanvasGroup.alpha = 0;
        CanvasGroup.interactable = false;
        CanvasGroup.blocksRaycasts = false;
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }
}
