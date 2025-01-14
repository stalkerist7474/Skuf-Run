using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;


    private void Start()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = SaveManager.Instance.MyData.MaxScore.ToString();
    }
}
