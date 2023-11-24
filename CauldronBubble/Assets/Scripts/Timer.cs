using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private GameManager gameManager;
    private float elapsedTime = 0;
    
    public bool isTimerRunning;
    public float elapsedTimeSeconds;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timerText.text = string.Format("Time: {0:00}:{1:00}", 0, 0);
    }

    public void StartTimer()
    {
        isTimerRunning = true;
        elapsedTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning && gameManager.isGameActive)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            elapsedTimeSeconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, elapsedTimeSeconds);
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
