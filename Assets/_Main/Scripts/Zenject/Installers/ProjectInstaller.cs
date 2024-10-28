using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{

    [SerializeField] 
    private PlayerModel playerModel;

    public override void InstallBindings()
    {

        this.Container
            .Bind<PlayerModel>()
            .FromInstance(this.playerModel)
            .AsSingle();
    }
}