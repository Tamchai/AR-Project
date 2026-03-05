using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsterPrefabs;

    public int waveCount = 3;
    public int monstersPerWave = 3;

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    IEnumerator StartWaves()
    {
        while (currentWave < waveCount)
        {
            currentWave++;
            Debug.Log("Wave " + currentWave);

            for (int i = 0; i < monstersPerWave; i++)
            {
                SpawnMonster();
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(5f);
        }

        Debug.Log("All waves complete!");
    }

    void SpawnMonster()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject monster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];

        Instantiate(monster, spawnPoint.position, spawnPoint.rotation);
    }
}