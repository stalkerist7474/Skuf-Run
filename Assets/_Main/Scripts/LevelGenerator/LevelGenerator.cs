using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour, 
    IEventSubscriber<PassSectionPlayerEvent>
{

    [SerializeField] private GameObject TestPrefabRoad;
    [SerializeField] private int rateOneCorridorTwoBlockWay;
    [SerializeField] private int FreeWay;

    private int countChank;
    private void Subscribe() 
    { 
        EventBus.RegisterTo(this as IEventSubscriber<PassSectionPlayerEvent>);
    }

    private void Unsubscribe() 
    {
        EventBus.UnregisterFrom(this as IEventSubscriber<PassSectionPlayerEvent>);
    }


    private void Start()
    {
        Subscribe();
        countChank = 0;
    }


    public void OnEvent(PassSectionPlayerEvent eventName)
    {
        Instantiate(TestPrefabRoad, eventName.PointSpawnNextSection.position, Quaternion.identity );
    }



    private void OnDestroy()
    {
        Unsubscribe();
    }
}
