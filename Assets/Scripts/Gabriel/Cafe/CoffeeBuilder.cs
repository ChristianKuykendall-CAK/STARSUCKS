using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CoffeeBuilder : MonoBehaviour
{
    public static CoffeeBuilder instance;
    public CafeSceneManager cafeSceneManager;
    public Coffee coffee;
    public int snappedObjCount = 0;
    
    public void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetTemp(CoffeeOptions.Temps tempChoice)
    {
        coffee.temp = tempChoice;
    }

    public void SetBloodType(CoffeeOptions.BloodTypes bloodTypeChoice)
    {
        coffee.bloodType = bloodTypeChoice;
    }

    public void SetTopping(CoffeeOptions.Toppings toppingChoice)
    {
        coffee.topping = toppingChoice;
    }

    public void SetSize(CoffeeOptions.Sizes sizeChoice)
    {
        coffee.size = sizeChoice;
    }

    public void SubmitOrder()
    {
        bool isCorrect;
        isCorrect = OrderManager.instance.CompareCoffeeToOrder(coffee);
        if (snappedObjCount < 2) isCorrect = false;
        if (isCorrect) cafeSceneManager.BeginNextEvent();
        else cafeSceneManager.DisplayDialog("This isn't what I ordered.");
        ClearCoffee();
    }
    
    public void ClearCoffee()
    {
        coffee = new Coffee();
        snappedObjCount = 0;
        Destroy(CupSizes.instance.currentCup);
    }
}
