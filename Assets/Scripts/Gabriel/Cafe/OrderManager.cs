
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public CafeSceneManager cafeSceneManager;
    public CoffeeOptions coffeeOptions;
    public List<Coffee> MainGirlOrders;
    [SerializeField] public Coffee currentOrder;

    private RandDialogs randDialogs;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void LoadJSONData()
    {
        randDialogs = JsonUtility.FromJson<RandDialogs>(Resources.Load<TextAsset>("randomDialogs").text);
    }

    public void GenerateNewOrder()
    {
        Coffee.Randomize(currentOrder);
        cafeSceneManager.DisplayDialog(GetOrderString());
        cafeSceneManager.DisplayPaperOrder(currentOrder.GetPrintDetails());
    }

    public void SetOrderByGirlIndex(int girlIndex) {
        currentOrder = MainGirlOrders[girlIndex];
        cafeSceneManager.DisplayPaperOrder(currentOrder.GetPrintDetails());
    }

    public string GetOrderString()
    {
        string randIntro = randDialogs.intros[Random.Range(0, randDialogs.intros.Length)];
        string randOutro = randDialogs.outros[Random.Range(0, randDialogs.outros.Length)];
        string toppingString = currentOrder.topping != 0 ? $" and {Coffee.ToDisplayString(currentOrder.topping)}" : "";
        string orderString = $"{randIntro} a {Coffee.ToDisplayString(currentOrder.size)} {Coffee.ToDisplayString(currentOrder.temp)} coffee with {Coffee.ReplaceSymbols(currentOrder.bloodType)} blood{toppingString}{randOutro}";
        return orderString;
    }

    public bool CompareCoffeeToOrder(Coffee coffee)
    {   
        bool isCorrect = false;
        if (
            coffee.temp == currentOrder.temp &&
            coffee.bloodType == currentOrder.bloodType &&
            coffee.topping == currentOrder.topping &&
            coffee.size == currentOrder.size &&
            coffee.hasCoffee
            ) /* then */ isCorrect = true;

        return isCorrect;
    }
}


[System.Serializable]
class RandDialogs
{
    public string[] intros;
    public string[] outros;
}