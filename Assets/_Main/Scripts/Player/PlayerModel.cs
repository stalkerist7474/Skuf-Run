using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TrigerPassSection"))
        {
            Debug.Log("SectionComplete");
            other.gameObject.GetComponentInParent<LevelSection>().SwitchOffSection();
            EventBus.RaiseEvent(new PassSectionPlayerEvent(other.gameObject.GetComponentInParent<LevelSection>().PointSpawnNextSection));
        }
    }
}
