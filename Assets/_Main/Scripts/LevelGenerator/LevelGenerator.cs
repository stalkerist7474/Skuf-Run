using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour, 
    IEventSubscriber<PassSectionPlayerEvent>
{

    [SerializeField] private GameObject TestPrefabRoad;
    [SerializeField] private int rateOneCorridorTwoBlockWay;
    [SerializeField] private int FreeWay;
    [SerializeField] private ObjectPoolRoad poolRoad;

    [SerializeField] private List<GameObject> listOneCorridorTwoBlockWay;
    [SerializeField] private List<GameObject> listFreeWay;
    [SerializeField] private List<GameObject> listTwoRampOneBlockWay;
    [SerializeField] private List<GameObject> listOneRampTwoBlockWay;

    private TypeChankRoad nextTypeChank;

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
        nextTypeChank = TypeChankRoad.OneCorridorTwoBlockWay;
        poolRoad.StartPreload();
    }


    public void OnEvent(PassSectionPlayerEvent eventName)
    {
        //Instantiate(TestPrefabRoad, eventName.PointSpawnNextSection.position, Quaternion.identity );
        SpawnNewChank(eventName.PointSpawnNextSection.position);
    }



    private void SpawnNewChank(Vector3 posSpawn)
    {
        //sdvig spawn new chank after starts chanks = 210
        Vector3 posWithOffset = new Vector3(posSpawn.x, posSpawn.y, (posSpawn.z + 210));

        if (countChank == 0)
        {
            GameObject newChank = TryGetGameObjectChank(nextTypeChank);
            InitNewChank(newChank, posWithOffset);
            CounterUpdate();
            UpdateNextChankType();
            return;
        }

        //
        if (countChank > 0)
        {
            GameObject newChank = TryGetGameObjectChank(nextTypeChank);
            InitNewChank(newChank, posWithOffset);
            CounterUpdate();
            UpdateNextChankType();
        }

    }


    private GameObject TryGetGameObjectChank(TypeChankRoad typeChankRoad)
    {
        if (typeChankRoad == TypeChankRoad.OneCorridorTwoBlockWay)
        {
            GameObject chank = ObjectPoolRoad.GetNextObject(listOneCorridorTwoBlockWay[Random.Range(0, listOneCorridorTwoBlockWay.Capacity)].gameObject, false);
            return chank;
        }

        if (typeChankRoad == TypeChankRoad.FreeWay)
        {
            GameObject chank = ObjectPoolRoad.GetNextObject(listFreeWay[Random.Range(0, listOneCorridorTwoBlockWay.Capacity)].gameObject, false);
            return chank;
        }

        if (typeChankRoad == TypeChankRoad.OneRampTwoBlockWay)
        {
            GameObject chank = ObjectPoolRoad.GetNextObject(listTwoRampOneBlockWay[Random.Range(0, listOneCorridorTwoBlockWay.Capacity)].gameObject, false);
            return chank;
        }

        if (typeChankRoad == TypeChankRoad.TwoRampOneBlockWay)
        {
            GameObject chank = ObjectPoolRoad.GetNextObject(listOneRampTwoBlockWay[Random.Range(0, listOneCorridorTwoBlockWay.Capacity)].gameObject, false);
            return chank;
        }
        else
            return null;
    }

    private void InitNewChank(GameObject gameObject, Vector3 posSpawn)
    {
        gameObject.transform.position = posSpawn;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
    }

    private void CounterUpdate()
    {
        if (countChank == 10)
        {
            countChank = 0;
        }
        else
            countChank++;
    }
    private void UpdateNextChankType()
    {
        if (countChank == 3 || countChank == 6 || countChank == 9)
        {
            nextTypeChank = TypeChankRoad.FreeWay;
            return;
        }
        if (countChank == 10)
        {
            nextTypeChank = TypeChankRoad.OneCorridorTwoBlockWay;
            return;
        }
        else
        {
            int randInt = Random.Range(-1, 0);
            if(randInt != 0)
            {
                nextTypeChank = TypeChankRoad.OneRampTwoBlockWay;
            }
            else
                nextTypeChank = TypeChankRoad.TwoRampOneBlockWay;
        }
    }












    private void OnDestroy()
    {
        Unsubscribe();
    }
}
