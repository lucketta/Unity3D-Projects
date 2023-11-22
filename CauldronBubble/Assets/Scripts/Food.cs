using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Food : MonoBehaviour
{
    private Rigidbody foodRb;
    private GameManager gameManager;

    private float maxTorque = 10;
    private float xSpawnRange = 4.5f;
    private float spawnPosY = 11.5f;
    private float spawnPosZ = -1;
    private int scoreValue = 10;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        if (!gameManager.isGameOver)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Bad Food"))
        {
            gameManager.badFoodCounter++;

            if (!gameManager.isGameOver)
            {
                gameManager.badFoodText.text += "X";
            }

            Debug.Log("Bad food counter: " + gameManager.badFoodCounter);

            if (gameManager.badFoodCounter == gameManager.gameOverCount)
            {
                Debug.Log("Game Over");

                gameManager.GameOver();
            }
        }
        else if (!gameManager.isGameOver)
        {
            gameManager.UpdateScore(scoreValue);
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        // calculate a spawnposition thats random along the top of the screen
        return new Vector3(Random.Range(-xSpawnRange, xSpawnRange), spawnPosY, spawnPosZ);
    }
}
