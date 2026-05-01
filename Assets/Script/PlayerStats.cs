using System.ComponentModel.Design;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    [Header("Player Stats")]
    public int currentHealth;
    public int damage;

    [Header("Level Up Config")]
    public float currentExperience;
    public float experienceToNextLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("References")]
    public GUIManager managerGUI;
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

    public void AddExperience(int experience)
    {
        currentExperience += experience;
        if(currentExperience >= experienceToNextLevel)
        {
            LevelUp();
        }
        Debug.Log("Player Gained " + experience + " Experience");
    }   
    
    public void LevelUp()
    {
        if(currentExperience >= experienceToNextLevel)
        {
            experienceToNextLevel *= 1.5f;
            managerGUI.GUILevelUp();
            Debug.Log("Level Up");
        }
    }
}
