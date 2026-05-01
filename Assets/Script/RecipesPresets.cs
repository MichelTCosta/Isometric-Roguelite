using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "RecipeCard", order = 1)]
public class RecipesPresets : ScriptableObject
{
    public string recipeName;
    public Sprite recipeImage;
    public string recipeDescription;
    public string recipeRarity;

  
}
