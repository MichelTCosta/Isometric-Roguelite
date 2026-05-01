using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [Header("Level Up Settings")]
    public GameObject levelUpUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GUILevelUp()
    {
        
        levelUpUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void CardSelected()
    {
        levelUpUI.SetActive(false);
        Time.timeScale = 1;
    }
}
