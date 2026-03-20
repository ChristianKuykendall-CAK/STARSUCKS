using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public CoffeeOptions coffeeOptions;
    [SerializeField] public Coffee currentOrder;
    public TMP_Text log;
    public TMP_Text log2;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        currentOrder = Coffee.Randomize(new Coffee());

        currentOrder.PrintDetails(log);
        currentOrder.PrintDetails(log2);
    }

    public void GenerateNewOrder()
    {
        Coffee.Randomize(currentOrder);
        currentOrder.PrintDetails(log);
    }

    public bool CompareCoffeeToOrder(Coffee coffee)
    {
        bool isCorrect = false;
        
        if (
            coffee.temp == currentOrder.temp &&
            coffee.bloodType == currentOrder.bloodType &&
            // coffee.topping == currentOrder.topping &&
            coffee.size == currentOrder.size
            ) /* then */ isCorrect = true;

        return isCorrect;
    }
}
