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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerStats = FindFirstObjectByType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        

        CloseToAttack();
    }


    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
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
