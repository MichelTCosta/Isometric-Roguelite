using UnityEngine;

public class Experience : MonoBehaviour
{

    Transform player;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        player = FindFirstObjectByType<PlayerStats>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, 10f * Time.deltaTime);
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FindFirstObjectByType<PlayerStats>().AddExperience(1);
            Destroy(this.gameObject);
        }
    }
}
