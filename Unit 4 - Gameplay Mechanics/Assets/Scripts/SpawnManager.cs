using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GenerateSpawnPoint()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
