using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody foodRb;
    private float maxTorque = 10;
    private float spawnRangeLeft = -38;
    private float spawnRangeRight = 30;
    private float spawnPosY = 80;
    private float spawnPosZ = -3;


    // Start is called before the first frame update
    void Start()
    {
        foodRb = GetComponent<Rigidbody>();
        foodRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        // calculate a spawnposition thats random along the top of the screen
        return new Vector3(Random.Range(spawnRangeLeft, spawnRangeRight), spawnPosY, spawnPosZ);
    }
}
