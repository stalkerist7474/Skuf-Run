using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRunParamChanger : MonoBehaviour
{
    [SerializeField] private List<Material> Material;


    private void Start()
    {
        Material[0].SetFloat("_SideWayPower", 0.0005f);
        Material[0].SetFloat("_BackWayPower", 0.0007f);

        Material[1].SetFloat("_SideWayPower", 0.0005f);
        Material[1].SetFloat("_BackWayPower", 0.0007f);
    }
}
