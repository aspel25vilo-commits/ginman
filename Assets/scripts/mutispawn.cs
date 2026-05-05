using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class mutispawn : MonoBehaviour
{
    public GameObject objectToSpawn; // The prefab to spawn
    public float spawnInterval = 2f; // Time interval between spawns
    private List<Transform> spawnPoints = new List<Transform>(); // List of spawn points
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {

            spawnPoints.Add(child);
        }

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        Instantiate(objectToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if (spawnPoints.Count == 0) 
            return;
        else {

            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

            Instantiate(objectToSpawn, randomSpawnPoint.position, randomSpawnPoint.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
