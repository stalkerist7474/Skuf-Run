using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Zenject;
using TMPro;

public class ParamsGamePlayBar : MonoBehaviour
{
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
        playerModel.UpdateScoreEvent
            .Subscribe(currentScore => UpdateScore(currentScore))
            .AddTo(disposable);
    }

    private void UpdateScore(int scoreValue)
    {
        scoreText.text = scoreValue.ToString();
    }







    private void OnDestroy()
    {
        disposable.Dispose();
    }
}
