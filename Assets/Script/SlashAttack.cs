using UnityEditor;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
    public EnemyManager enemyManager;

    public int attackDamage;
    public float attackTimer;
    public float attackRange;
    private float attackCounter;

    private Transform closestEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(attackCounter < attackTimer)
        {
            attackCounter += Time.deltaTime;

        }
        if(attackCounter >= attackTimer) 
        {
            attackCounter = 0f;
            AttackClosestEnemy();
                
        }
    }

    public void AttackClosestEnemy()
    {
        if(enemyManager.enemies.Count <= 0) return;
        closestEnemy = enemyManager.closestEnemyToPlayer.transform;

        if(closestEnemy != null && (closestEnemy.position - transform.position).sqrMagnitude <= attackRange * attackRange)
        {
            closestEnemy.GetComponent<EnemyStats>().TakeDamage(attackDamage);
            Debug.Log("Attacked Enemy");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Set the color for the gizmo
        Gizmos.color = Color.red;
        
        // Draw a wire sphere at the object's position with the specified radius
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}
