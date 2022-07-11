﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float dogSpawnRate = 1.0f;
    private float dogSpawnTime;

    void Start()
    {
        dogSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= dogSpawnTime)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            dogSpawnTime = Time.time + dogSpawnRate;
        }
    }
}
