using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOffRoadObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrigerOff"))
        {
            Debug.Log("SectionOff");
            other.gameObject.GetComponentInParent<LevelSection>().gameObject.SetActive(false);
            
        }
    }
}
