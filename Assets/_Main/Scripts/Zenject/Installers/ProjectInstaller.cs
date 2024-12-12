using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{

    [SerializeField] 
    private PlayerModel playerModel;
    [SerializeField]
    private GameManager gameManager;

    public override void InstallBindings()
    {

        this.Container
            .Bind<PlayerModel>()
            .FromInstance(this.playerModel)
            .AsSingle();

        this.Container
            .Bind<GameManager>()
            .FromInstance(this.gameManager)
            .AsSingle();
    }
}