using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlock;
    public Vector2 timeBetweenSpawnMinMax;
    private float nextSpawnTime;
    public float spawnAngleMax;

    public Vector2 spawnSizeMinMax;

    private Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(timeBetweenSpawnMinMax.y, timeBetweenSpawnMinMax.x, Difficulty.GetDifficultyPercent());

            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawnPoint = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingBlock, spawnPoint, Quaternion.Euler(Vector3.forward * spawnAngle));
            newBlock.transform.localScale = Vector2.one * spawnSize;
        }

        
    }
}
