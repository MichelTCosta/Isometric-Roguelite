using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    public Transform playerTransform;

    [Header("Enemy Stats")]
    public float moveSpeed;
    
    public float distanceToStopFromPlayer;

    public bool isEnabled = true;
    private Rigidbody rb;
    public float distanceToPlayer;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = FindFirstObjectByType<PlayerStats>().transform;
        transform.LookAt(playerTransform);


    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            distanceToPlayer = (transform.position - playerTransform.position).sqrMagnitude;

            if(distanceToPlayer > distanceToStopFromPlayer)
            {
                rb.MovePosition(Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed));

            }

            if(distanceToPlayer <= distanceToStopFromPlayer)
            {
                GetComponent<EnemyStats>().isCloseToAttack = true;
                isEnabled = false;
            }
            
        }

        
    }
}
