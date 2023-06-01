using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public GameObject enemy;
    public int amount = 25;
    public float MaxX = 23f;
    public float MaxY = 23f;
    public float MinX = -23f;
    public float MinY = -23f;
    private Vector2 spawnPosition;

    public void Start()
    {
        //Spawn amount enemies at random spots
        for(int i = 0; i < amount; i++)
        {
            spawnPosition.x = Random.value < 0.5f ? Random.Range(MinX, -10f) : Random.Range(10f, MaxX);
            spawnPosition.y = Random.value > 0.5f ? Random.Range(MinY, -10f) : Random.Range(10f, MaxY);
            Vector2 randomVelocity = new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f));
            GameObject enemySpawned = Instantiate(enemy, spawnPosition, Quaternion.identity);
            enemySpawned.GetComponent<Rigidbody2D>().velocity = randomVelocity;

        }
    }
}
