using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRunParamChanger : MonoBehaviour
{
    [SerializeField] private List<Material> Material;
    [Space]
    [SerializeField] private float stepChange = 0.000002f;
    [Space]
    [Space]
    [SerializeField] private float horizontalMin;
    [SerializeField] private float horizontalMax;
    [Space]
    [Space]
    [SerializeField] private float verticalMin;
    [SerializeField] private float verticalMax;

    private bool directionHorizontal = true;

    private float horizontalCurrent;
    private float verticalCurrent;


    private void Start()
    {
        Material[0].SetFloat("_SideWayPower", 0.0005f);
        Material[0].SetFloat("_BackWayPower", 0.0007f);

        Material[1].SetFloat("_SideWayPower", 0.0005f);
        Material[1].SetFloat("_BackWayPower", 0.0007f);

        StartCoroutine(StartChangeHorizontal());
    }

    private void ChangeParamShaider(string nameParam, float value)
    {
        foreach (Material mat in Material)
        {
            mat.SetFloat(nameParam, value);
        }
    }


    IEnumerator StartChangeHorizontal()
    {
        while (true)
        {
            if (directionHorizontal)
            {
                horizontalCurrent += stepChange;        
                if (horizontalCurrent >= horizontalMax) 
                {
                    horizontalCurrent = horizontalMax;                 
                    directionHorizontal = false; 
                }
            }

            else
            {
                horizontalCurrent -= stepChange; 
                if (horizontalCurrent <= horizontalMin) 
                {
                    horizontalCurrent = horizontalMin;                  
                    directionHorizontal = true; 
                }
            }

            
            ChangeParamShaider("_SideWayPower", horizontalCurrent);

            yield return new WaitForSeconds(0.1f);
        }
    }
}
