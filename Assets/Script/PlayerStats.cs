using System.ComponentModel.Design;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [Header("Player Stats")]
    public int currentHealth;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Player Is Dead!!!");
    }
}
