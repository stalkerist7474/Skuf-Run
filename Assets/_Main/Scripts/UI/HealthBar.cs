using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using R3;
using Zenject;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject prefabHearth;
    [SerializeField] private List<GameObject> listHearth;

    private PlayerModel playerModel;
    private CompositeDisposable disposable = new CompositeDisposable();




    private void Awake()
    {
        //playerModel.InitHealthBarNewLevel
        //    .Subscribe(maxCountHealth => Init(maxCountHealth))
        //    .AddTo(disposable);

        playerModel.RemoveHeart
            .Subscribe(count => RemoveHearth(count))
            .AddTo(disposable);
        Debug.Log("AwakeHearth");
    }

    private void Start()
    {
        Init(playerModel.MaxCountHealth);
        Debug.Log("StartAddHearth");
    }

    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        this.playerModel = playerModel;
        Debug.Log("Construct");
    }

    private void Init(int countHearth)
    {
        if (listHearth != null)
        {
            foreach (var item in listHearth)
            {
                Destroy(item.gameObject);
            }
        }

        for (int i = 0; i < countHearth; i++)
        {
            AddHearth();
            Debug.Log("AddHearth");
        }
    }

    private void AddHearth()
    {
        var hearth = Instantiate(prefabHearth, this.transform.position, Quaternion.identity, this.transform);
        listHearth.Add(hearth);
    }

    private void RemoveHearth(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var heart = listHearth[listHearth.Count - 1];
            listHearth.Remove(heart);
            Destroy(heart.gameObject);
            Debug.Log("RemoveHearth");
        }
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }

}
