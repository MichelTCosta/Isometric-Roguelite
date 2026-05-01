using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    //Private References
    private PlayerStats playerStats;


    [Header("Enemy Stats")]
    public int currentHealth;
    public int damage;
    public float timeToAttack;
    private float timeToAttackCounter;

    private int attackCount;
    public bool isCloseToAttack;
    public Renderer enemyRenderer;
    private EnemyManager enemyManager;
    public GameObject deathParticle;


    public GameObject experiencePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
        enemyManager = FindFirstObjectByType<EnemyManager>();
        enemyManager.AddToList(this.gameObject);
    
    }

    // Update is called once per frame
    void Update()
    {
        CloseToAttack();
    }


    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        if(enemyRenderer != null)
        {
            enemyRenderer.material.color = Color.black;
            Invoke("ResetColor", 0.2f);
        }
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void ResetColor()
    {
        enemyRenderer.material.color = Color.white;
    }

    public void Death()
    {
        Instantiate(experiencePrefab, transform.position, Quaternion.identity);
        Instantiate(deathParticle, transform.position, Quaternion.identity);
        enemyManager.RemoveFromList(this.gameObject);
        Destroy(this.gameObject);
    }

    public void CloseToAttack()
    {
        if (isCloseToAttack)
        {
            timeToAttackCounter += Time.deltaTime;
            if(timeToAttackCounter >= timeToAttack)
            {
                playerStats.TakeDamage(damage);
                Debug.Log("Enemy Attacked" + attackCount);
                attackCount++;
                timeToAttackCounter = 0;
            }
            
        }
    }
}
