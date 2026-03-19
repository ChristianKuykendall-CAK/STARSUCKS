using UnityEngine;

public class CoffeeBuilder : MonoBehaviour
{
    public static CoffeeBuilder instance;
    public Coffee coffee;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
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
        bool isCorrect = OrderManager.instance.CompareCoffeeToOrder(coffee);
        Debug.Log(isCorrect);
    }    
}
