using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionWave : MonoBehaviour
{
    //волна врагов
    bool isSpawning = false;
    public float MinSpawnTime = 5f;
    public float MaxSpawnTime = 5f;
    public GameObject[] enemies;//массив врагов расположених как попало

    IEnumerator SpawnObject(int index, float seconds)
    {
        yield return new WaitForSeconds(seconds);// количество времени перед распростронения
        Instantiate(enemies[index], transform.position, transform.rotation);
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;//пораждение пришельцев 
            int enemyIndex = Random.Range(0, enemies.Length);
            StartCoroutine(SpawnObject(enemyIndex, Random.Range(MinSpawnTime, MaxSpawnTime)));//наплыв пришельцев
        }
    }
}
