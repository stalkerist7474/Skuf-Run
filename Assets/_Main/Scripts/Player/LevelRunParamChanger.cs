using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRunParamChanger : MonoBehaviour
{
    [SerializeField] private List<Material> Material;
    [Space]
    [SerializeField] private double stepChange = 0.000002f;
    [SerializeField] private float delayChange = 0.2f;
    [SerializeField] private float delayChangeSpeedMove = 0.1f;
    [SerializeField] private float MaxSpeedPlayer = 1f;
    [Space]
    [Space]
    [SerializeField] private double horizontalMin;
    [SerializeField] private double horizontalMax;
    [Space]
    [Space]
    [SerializeField] private double verticalMin;
    [SerializeField] private double verticalMax;

    private bool directionHorizontal = true;
    private bool directionVertical = true;

    private double horizontalCurrent;
    private double verticalCurrent;


    private void Start()
    {
        Material[0].SetFloat("_SideWayPower", 0.0005f);
        Material[0].SetFloat("_BackWayPower", 0.0007f);

        Material[1].SetFloat("_SideWayPower", 0.0005f);
        Material[1].SetFloat("_BackWayPower", 0.0007f);

        StartCoroutine(StartChangeHorizontal());
        StartCoroutine(StartChangeVertical());
        StartCoroutine(StartChangePlayerSpeedMove());
    }

    private void ChangeParamShaider(string nameParam, double value)
    {
        foreach (Material mat in Material)
        {
            mat.SetFloat(nameParam, (float)value);
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

            yield return new WaitForSeconds(delayChange);
        }
    }

    IEnumerator StartChangeVertical()
    {
        while (true)
        {
            if (directionVertical)
            {
                verticalCurrent += stepChange;
                if (verticalCurrent >= verticalMax)
                {
                    verticalCurrent = verticalMax;
                    directionVertical = false;
                }
            }

            else
            {
                verticalCurrent -= stepChange;
                if (verticalCurrent <= verticalMin)
                {
                    verticalCurrent = verticalMin;
                    directionVertical = true;
                }
            }


            ChangeParamShaider("_BackWayPower", verticalCurrent);

            yield return new WaitForSeconds(delayChange);
        }
    }
    IEnumerator StartChangePlayerSpeedMove()
    {
        while (PlayerMovementCC.Instance.Speed < MaxSpeedPlayer)
        {

            PlayerMovementCC.Instance.Speed += 0.01f;

            yield return new WaitForSeconds(delayChangeSpeedMove);
        }
    }
}
