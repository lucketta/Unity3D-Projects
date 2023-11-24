using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Food : MonoBehaviour
{
    public AudioClip goodSound;
    public AudioClip badSound;
    public AudioClip destroySound;

    private Rigidbody foodRb;
    private GameManager gameManager;

    private float maxTorque = 1;
    private float xSpawnRange = 4.3f;
    private float spawnPosY = 11.5f;
    private float spawnPosZ = -1;
    private int scoreValue = 10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        foodRb = GetComponent<Rigidbody>();
        foodRb.AddTorque(0, 0, RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.ingredientSound.PlayOneShot(destroySound, 1.0f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Bad Food") && gameManager.isGameActive)
        {
            gameManager.badFoodCounter++;
            gameManager.badFoodText.text += "X";
            
            if (gameManager.badFoodCounter == gameManager.gameOverCount)
            {
                gameManager.GameOver();
            }

            gameManager.ingredientSound.PlayOneShot(badSound, 1.0f);
        }
        else if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(scoreValue);
            gameManager.ingredientSound.PlayOneShot(goodSound, .25f);
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
