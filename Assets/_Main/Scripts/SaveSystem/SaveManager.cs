using R3;
using System.Collections;
using UnityEngine;
using Zenject;

public class SaveManager : IGameSystem
{
    public static SaveManager Instance;
    private ISaveSystem _saveSystem;
    public SaveData MyData;
    [SerializeField] private SaveData _myDefaultData;

    [SerializeField] private GameManager _gameManager;
    private CompositeDisposable _compositeDisposable = new CompositeDisposable();

    public SaveData MyDefaultData => _myDefaultData;

    private void Awake()
    {
        if (SaveManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _saveSystem = new JsonSaveSystem(); //���� ��� ������ ������ ���������� �����������
        MyData = _saveSystem.Load();

        //UniRX

        _gameManager.NewGameStateEventRx
            .Subscribe(currentGameState => ReactEvent(currentGameState))
            .AddTo(_compositeDisposable);
    }

    [Inject]
    public void Construct(GameManager gameManager)
    {
        this._gameManager = gameManager;
    }


    private void ReactEvent(GameState state)
    {
        Debug.Log(state.ToString());
    }

    public void Save()
    {
        _saveSystem.Save(MyData);
    }

    public void Load()
    {
        MyData = _saveSystem.Load();

        //if (RemoteConfigManager.Instance != null && RemoteConfigManager.Instance.IsReady)
        //    MyData.RemoveAds = (bool)RemoteConfigManager.Instance?.GetRemoteBool("RemoveAdsGoogle");
        Save();
    }

    public void SetDefaultSaveData()
    {
        _saveSystem.Save(MyDefaultData);
        Load();
    }

    public override void Activate()
    {
        this.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _compositeDisposable.Dispose();
    }
}