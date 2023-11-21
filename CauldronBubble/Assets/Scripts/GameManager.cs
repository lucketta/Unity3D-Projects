using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> foods;
    private Timer elapsedTime;
    private float spawnRate = 1.0f;
    private float timeLowerBound = 0;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = GameObject.Find("Timer Text").GetComponent<Timer>();

        StartCoroutine(SpawnFood());
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

    IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, foods.Count);
            Instantiate(foods[index]);
        }
    }
}
