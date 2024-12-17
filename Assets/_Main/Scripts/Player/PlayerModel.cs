using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{

    // skin

    // value res





    



    //methods triggers load zone
    public void OnTriggerSpawnNewzone(Collider other)
    {
        if (other.gameObject.CompareTag("TrigerPassSection"))
        {
            Debug.Log("SectionComplete");
            other.gameObject.GetComponentInParent<LevelSection>().SwitchOffSection();
            EventBus.RaiseEvent(new PassSectionPlayerEvent(other.gameObject.GetComponentInParent<LevelSection>().PointSpawnNextSection));
        }
    }

    //methods interact object
    public void OnTriggerInteractObject(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            
        }
        if (other.gameObject.CompareTag("ObstacleDie"))
        {
            Debug.Log("ObstacleDie");

        }
    }
}
