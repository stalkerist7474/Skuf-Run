using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSection : MonoBehaviour
{
    [SerializeField] private Transform pointSpawnNextSection;
    [SerializeField] private GameObject gameObjectSection;
    [SerializeField] private float delayOff;
    [SerializeField] private TypeChankRoad typeChank;

    [SerializeField] private bool isStartChank= false;

    public Transform PointSpawnNextSection { get => pointSpawnNextSection; set => pointSpawnNextSection = value; }


    public void SwitchOffSection()
    {
        StartCoroutine(SwitchGameobject());
    }

    private IEnumerator SwitchGameobject()
    {
        yield return new WaitForSecondsRealtime(delayOff);
        gameObjectSection.SetActive(false);
    }
}
