using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSo> waveConfigs ;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool IsLooping = false;
    WaveConfigSo currentWave;


    void Start()
    {
        StartCoroutine(SpawnEnemyWaves()); 
    }
    public WaveConfigSo GetCurrentWave()
    {
        return currentWave;
    }
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
           foreach (WaveConfigSo wave in waveConfigs)//for each wave in the list of waveConfigs
           {
            currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)

                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                            currentWave.GetStartingWaypoint().position,
                            Quaternion.Euler(0,0,180),
                            transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            yield return new WaitForSeconds(timeBetweenWaves);
           }
        } 
        
        while (IsLooping);
                        
        
    }



}
