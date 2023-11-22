using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> foods;
    public bool isGameOver;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI badFoodText;

    private Timer elapsedTime;
    private float spawnRate = 1.0f;
    private float timeLowerBound = 0;
    public int gameOverCount = 3;
    public int badFoodCounter = 0;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = GameObject.Find("Timer Text").GetComponent<Timer>();
        score = 0;
        badFoodText.text = "Bad: ";

        StartCoroutine(SpawnFood());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime.elapsedTimeSeconds == 0)
        {
            timeLowerBound = 0;
        }

        if (elapsedTime.elapsedTimeSeconds > timeLowerBound && elapsedTime.elapsedTimeSeconds % 15 == 0 && spawnRate > .25f)
        {
            //Debug.Log("Elapsed Time: " + elapsedTime.elapsedTimeSeconds);

            timeLowerBound = elapsedTime.elapsedTimeSeconds;
            //Debug.Log("lower bound Time: " + timeLowerBound);
            spawnRate -= .25f;
            //Debug.Log("spawnRate after: " + spawnRate);
        }
    }

    void StartGame()
    {

    }

    IEnumerator SpawnFood()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foods.Count);
            Instantiate(foods[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
    }
}
