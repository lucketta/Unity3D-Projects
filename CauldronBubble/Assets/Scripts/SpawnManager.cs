using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay = 2;
    public float repeatRate = 1.5f;
    private float spawnRangeLeft = -38;
    private float spawnRangeRight = 30;
    private float spawnPosY = 80;
    private float spawnPosZ = -2;

    public GameObject[] foodPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFood", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomFood()
    {
        // Randomly pick index of array
        int foodIndex = Random.Range(0, foodPrefabs.Length);

        // calculate a spawnposition thats random along the top of the screen
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeLeft, spawnRangeRight), spawnPosY, spawnPosZ);
        // spawn the actor
        Instantiate(foodPrefabs[foodIndex], spawnPos, transform.rotation);
    }
}
