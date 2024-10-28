using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private PlayerModel playerModel;


    [Inject]
    public void Construct(PlayerModel playerModel)
    {
        this.playerModel = playerModel;
    }








    //new zone load
    private void OnTriggerExit(Collider other)
    {
        //spawn new zone
        this.playerModel.OnTriggerSpawnNewzone(other);
    }
}
