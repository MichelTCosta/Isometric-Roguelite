using UnityEngine;

public class CraftingMenuAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCraftingMenu()
    {
        // Toggle the active state of the crafting menu
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
