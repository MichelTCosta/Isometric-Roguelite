using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> enemies = new List<GameObject>();

    public GameObject closestEnemyToPlayer;

    public float gameTime;

    private GameObject player;

    [Header("Enemy Spawn Configs")]
    public Transform[] enemySpawns;

    public float spawnRate;
    public float spawnRateAdding;

    public float timerToSpawn;

    private float counterToSpawn;
    private int spawnedEnemyCounter;
    private bool spawningEnemys;

    [Header("Enemy Get Stronger")]
    public float enemyGrowStrongerTimer;
    private float enemyGrowCounter;

    public int enemyHealth;

    public int enemyHealthAdd;




    public GameObject enemyPrefab; //make a way to spawn different types of enemys

    public InputAction inputAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerStats>().gameObject;
    }
    void OnEnable() 
    {
        inputAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;



        EnemySpawningTimer();
        EnemyGrowStronger();
        SpawnEnemy();

        if (inputAction.WasPressedThisFrame())
        {
            Instantiate(enemyPrefab);
        }
    }

    private void FixedUpdate() {
       EnemyCloserToPlayer();
    }


    public void EnemySpawningTimer()
    {
        if(counterToSpawn < timerToSpawn)
        {
            counterToSpawn += Time.deltaTime;
            if(counterToSpawn >= timerToSpawn)
            {
                spawningEnemys = true;
                counterToSpawn = 0;
            }
        }
    }
    
    public void SpawnEnemy()
    {
        if(spawningEnemys && spawnedEnemyCounter < spawnRate)
        {

            var spawnPointSelected = Random.Range(0, enemySpawns.Length);

                Instantiate(enemyPrefab, enemySpawns[spawnPointSelected].position, Quaternion.identity);
                spawnedEnemyCounter ++;

               
            if(spawnedEnemyCounter >= spawnRate)
            {
                spawningEnemys = false;
                spawnedEnemyCounter = 0;
            }

        }
    }

    public void EnemyGrowStronger()
    {
        if(enemyGrowCounter < enemyGrowStrongerTimer)
        {
            enemyGrowCounter += Time.deltaTime;
            if(enemyGrowCounter >= enemyGrowStrongerTimer)
            {
                enemyHealth += enemyHealthAdd;
                spawnRate += spawnRateAdding;
                enemyGrowCounter = 0;
            }
        }
    }
    public void EnemyCloserToPlayer()
    {
        if(enemies.Count <= 0) return;


        float minValue = float.MaxValue;
        foreach(GameObject enemy in enemies)
        {

           if(enemy.GetComponent<EnemyMovement>().distanceToPlayer < minValue)
           {
               minValue = enemy.GetComponent<EnemyMovement>().distanceToPlayer;
               closestEnemyToPlayer = enemy.gameObject;
           }
    
        }
    }



    public void AddToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveFromList(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
