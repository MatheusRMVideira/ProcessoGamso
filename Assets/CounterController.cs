using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterController : MonoBehaviour
{
    private EnemySpawnerController enemySpawner;
    private int totalEnemies = 0;
    private Text text;
    public GameObject screenPrefab;
    private bool victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawnerController>();
        totalEnemies = enemySpawner.amount;
        text = gameObject.GetComponent<Text>();
        victoryScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("isEnemy").Length;
        if (enemyCount == 0)
        {
            text.text = string.Empty;
            if (!victoryScreen)
            {
                Instantiate(screenPrefab);
                victoryScreen=true;
            }
        }
        else
        {
            text.text = string.Format(enemyCount.ToString() + "/" + totalEnemies.ToString());
        }
    }
}
