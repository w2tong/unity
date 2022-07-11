using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRate = 2.5f;
    private float[] xSpawnPos = new float[] { -5, 5 };
    [SerializeField] GameObject vehiclePrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnVehicle", 0, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnVehicle()
    {
        int index = Random.Range(0, xSpawnPos.Length);
        Instantiate(vehiclePrefab, new Vector3(xSpawnPos[index], 0, 180), vehiclePrefab.gameObject.transform.rotation);
    }
}
