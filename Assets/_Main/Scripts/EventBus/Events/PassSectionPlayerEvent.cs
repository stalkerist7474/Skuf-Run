
using UnityEngine;

public struct PassSectionPlayerEvent : IEvent
{
    
    public Transform PointSpawnNextSection;


    public PassSectionPlayerEvent(Transform pointSpawnNextSection)
    {
        PointSpawnNextSection = pointSpawnNextSection;
    }
}
