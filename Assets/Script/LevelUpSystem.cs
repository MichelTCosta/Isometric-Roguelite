using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSystem : MonoBehaviour
{
    public GameObject recipeCardPrefab;
    public GameObject recipesGrid;
    public int cardsCreated;
    public List<GameObject> recipeCards = new List<GameObject>();
    public GUIManager managerGUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClearRecipeCards();
        CreateRecipeCard();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateRecipeCard()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject card = Instantiate(recipeCardPrefab, transform.position, recipeCardPrefab.transform.rotation, recipesGrid.transform);
            card.GetComponent<Button>().onClick.AddListener(managerGUI.CardSelected);

            recipeCards.Add(card);
            cardsCreated++;
        }
    }

    public void ClearRecipeCards()
    {
        foreach(GameObject card in recipeCards)
        {
            Destroy(card);
        }
        cardsCreated = 0;
        recipeCards.Clear();
    }
}
