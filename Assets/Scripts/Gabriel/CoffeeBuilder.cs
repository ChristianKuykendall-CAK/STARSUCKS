using UnityEngine;
using TMPro;

public class CoffeeBuilder : MonoBehaviour
{
    public static CoffeeBuilder instance;
    public Coffee coffee;
    public int snappedObjCount = 0;

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
        if (snappedObjCount < 2) return;
        bool isCorrect = OrderManager.instance.CompareCoffeeToOrder(coffee);
        GameObject.Find("TestTest").GetComponent<TMP_Text>().text = isCorrect ? "Yippee" : "Aw man, no.";
    }
}
