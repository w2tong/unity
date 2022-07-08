using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    // Top spawn pos
    private float spawnRangeX = 12;
    private float spawnPosZ = 20;

    // Left and right spawn pos
    private float spawnRangeZ = 15;
    private float leftSpawnPosX = -30;
    private float rightSpawnPosX = 30;

    private float startDelay = 1;
    private float spawnInterval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int direction = Random.Range(0, 3);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Quaternion rotation = animalPrefabs[animalIndex].transform.rotation;

        switch (direction)
        {
            // Top spawn
            case 0:
                spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
                rotation = animalPrefabs[animalIndex].transform.rotation;
                break;
            // Left spawn
            case 1:
                spawnPos = new Vector3(leftSpawnPosX, 0, Random.Range(0, spawnRangeZ));
                rotation = Quaternion.Euler(0, 90, 0);
                break;
            // Right spawn
            case 2:
                spawnPos = new Vector3(rightSpawnPosX, 0, Random.Range(0, spawnRangeZ));
                rotation = Quaternion.Euler(0, -90, 0);
                break;
            default:
                break;
        }
        Instantiate(animalPrefabs[animalIndex], spawnPos, rotation);
    }
}
