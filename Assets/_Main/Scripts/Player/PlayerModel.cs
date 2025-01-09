using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using System;

public class PlayerModel : MonoBehaviour, IEventSubscriber<NewGameStateEvent>
{
    [SerializeField] private int maxCountHealth = 3;

    private int currentHealth;
    private int currentScore = 10;
    private int currentCoin;
    // skin

    // value res

    public readonly Subject<int> ShowLoseScreenEvent = new Subject<int>();
    public readonly Subject<int> UpdateScoreEvent = new Subject<int>();
    public readonly Subject<int> RemoveHeartEvent = new Subject<int>();

    private CompositeDisposable disposable = new CompositeDisposable();

    public int MaxCountHealth { get => maxCountHealth; }

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
        if (eventName.NewState == GameState.Gameplay)
        {
            ResetHealth();
            ResetScore();
            StartCoroutine(StartScoreAddCor());
            Debug.Log("NewGameStateEvent PlayerModel");
        }
    }

    private void Start()
    {
        Subscribe();
    }

    #region HealtLogic


    private void RemoveHealth(int valueRemove)
    {
        currentHealth -= valueRemove;
        RemoveHeartEvent.OnNext(1);
        CheckHealth();
        Debug.Log("RemoveHealth");
    }

    private void AddHealth(int valueAdd)
    {
        currentHealth += valueAdd;
    }

    private void ResetHealth()
    {
        currentHealth = maxCountHealth;
        Debug.Log("ResetHealth");
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("YOU Die");
        ShowLoseScreenEvent.OnNext(currentScore);
        ScoreResult();
    }

    #endregion


    #region Interact block


    //methods triggers load zone
    public void OnTriggerSpawnNewzone(Collider other)
    {
        if (other.gameObject.CompareTag("TrigerPassSection"))
        {
            //Debug.Log("SectionComplete");
            other.gameObject.GetComponentInParent<LevelSection>().SwitchOffSection();
            EventBus.RaiseEvent(new PassSectionPlayerEvent(other.gameObject.GetComponentInParent<LevelSection>().PointSpawnNextSection));
        }
    }

    //methods interact object
    public void OnTriggerInteractObject(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            RemoveHealth(1);
            Debug.Log("Obstacle");
            
        }
        if (other.gameObject.CompareTag("ObstacleDie"))
        {
            Debug.Log("ObstacleDie");
            Die();
        }
    }

    #endregion

    #region ScoreLogic

    //private void StartScoreAdd()
    //{
    //    ResetScore();
    //    float intervalAdd = 0.2f;
    //    Observable
    //        .Interval(TimeSpan.FromSeconds(intervalAdd))
    //        .Subscribe(_ => AddScore())
    //        .AddTo(disposable);

    //}

    private IEnumerator StartScoreAddCor()
    {
        float intervalAdd = 0.2f;
        while (true)
        {
            yield return new WaitForSeconds(intervalAdd);
            AddScore(); 
        }
    }

    private void AddScore()
    {
        currentScore += 1;
        UpdateScoreEvent.OnNext(currentScore);
    }

    private void ResetScore()
    {
        currentScore = 0;
        UpdateScoreEvent.OnNext(currentScore);
    }

    private void ScoreResult()
    {
        StopAllCoroutines();
        if (currentScore > SaveManager.Instance.MyData.MaxScore)
        {
            SaveManager.Instance.MyData.MaxScore = currentScore;
            SaveManager.Instance.Save();
        }
        
    }

    #endregion

    private void OnDestroy()
    {
        Unsubscribe();
        disposable.Dispose();
    }
}
