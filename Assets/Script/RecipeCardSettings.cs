using TMPro;
using UnityEngine;
using System.Collections.Generic; 

public class RecipeCardSettings : MonoBehaviour
{

    public List<RecipesPresets> recipePreset; 
    
    public TMP_Text recipeName;
    public TMP_Text recipeDescription;
    public TMP_Text recipeRarity;

    private void Start() 
    {
        randomizeCard();
    }

    public void randomizeCard()
    {

        if (recipePreset == null || recipePreset.Count == 0) return;

        int randomIndex = Random.Range(0, recipePreset.Count);
        var selectedRecipe = recipePreset[randomIndex];
        
        recipeName.text = selectedRecipe.recipeName;
        recipeDescription.text = selectedRecipe.recipeDescription;
        recipeRarity.text = selectedRecipe.recipeRarity;


        Color rarityColor = Color.white;

        switch (selectedRecipe.recipeRarity)
        {
            case "Uncommon": rarityColor = Color.green; break;
            case "Rare": rarityColor = Color.blue; break;
            case "Epic": rarityColor = new Color(0.6f, 0f, 0.6f); break;
            case "Legendary": rarityColor = Color.yellow; break;
            default: rarityColor = Color.white; break;
        }


        recipeRarity.color = rarityColor;

        recipePreset.RemoveAt(randomIndex); 
    }
}
