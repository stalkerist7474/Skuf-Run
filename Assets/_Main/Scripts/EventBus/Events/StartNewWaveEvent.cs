
using UnityEngine;

//Start new wave in world battle
public struct StartNewWaveEvent : IEvent
{
    public readonly int WaveNumber;
    public bool IsBossWave;
    public GameObject EnemyPrefab;
    public float DelaySpawn;
    public int CountSpawn;

    public StartNewWaveEvent(int waveNumber, bool isBossWave, GameObject enemyPrefab, float delaySpawn, int countSpawn)
    {
        WaveNumber = waveNumber;
        IsBossWave = isBossWave;
        EnemyPrefab = enemyPrefab;
        DelaySpawn = delaySpawn;
        CountSpawn = countSpawn;
    }
}
