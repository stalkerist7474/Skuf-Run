using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour, IEventSubscriber<NewGameStateEvent>
{
    [SerializeField] private int maxCountHealth = 3;

    private int currentHealth;
    private int currentScore;
    private int currentCoin;
    // skin

    // value res

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
        }
    }

    private void Start()
    {
        Subscribe();
    }

    private void RemoveHealth(int valueRemove)
    {
        currentHealth -= valueRemove;
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
        EventBus.RaiseEvent(new NewGameStateEvent(GameState.Gameplay, GameState.Menu));
    }



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

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
