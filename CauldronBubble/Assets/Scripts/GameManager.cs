using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> foods;
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI badFoodText;
    public Button restartButton;
    public AudioSource ingredientSound;
    public AudioClip gameOverSound;

    private Timer timerComponent;
    private float spawnRate = 1.0f;
    private float timeLowerBound = 0;
    public int gameOverCount = 3;
    public int badFoodCounter = 0;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        timerComponent = GameObject.Find("Timer Text").GetComponent<Timer>();
        ingredientSound = GetComponent<AudioSource>();
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerComponent.elapsedTimeSeconds == 0)
        {
            timeLowerBound = 0;
        }

        if (timerComponent.elapsedTimeSeconds > timeLowerBound && timerComponent.elapsedTimeSeconds % 15 == 0 && spawnRate > .25f)
        {
            //Debug.Log("Elapsed Time: " + timerComponent.elapsedTimeSeconds);

            timeLowerBound = timerComponent.elapsedTimeSeconds;
            //Debug.Log("lower bound Time: " + timeLowerBound);
            spawnRate -= .25f;
            //Debug.Log("spawnRate after: " + spawnRate);
        }
    }

    public void StartGame()
    {
        timerComponent.StartTimer();
        isGameActive = true;
        ingredientSound.Play();
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (isGameActive)
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
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        ingredientSound.Stop();
        ingredientSound.PlayOneShot(gameOverSound, .5f);
        timerComponent.StopTimer();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
