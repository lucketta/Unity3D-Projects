using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;

    public float elapsedTimeSeconds;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        elapsedTimeSeconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, elapsedTimeSeconds);
    }
}
