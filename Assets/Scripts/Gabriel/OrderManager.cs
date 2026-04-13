using TMPro;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;
    public CoffeeOptions coffeeOptions;
    [SerializeField] public Coffee currentOrder;
    public TMP_Text nameBox;
    public TMP_Text dialogBox;
    public TMP_Text orderPaper;
    private RandDialogs randDialogs;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        randDialogs = JsonUtility.FromJson<RandDialogs>(Resources.Load<TextAsset>("randomDialogs").text);

        Debug.Log(randDialogs.intros);

        GenerateNewOrder();
    }

    public void GenerateNewOrder()
    {
        Coffee.Randomize(currentOrder);
        PrintDetails(GetOrderString());
        orderPaper.text = currentOrder.GetPrintDetails();
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
            // coffee.topping == currentOrder.topping &&
            coffee.size == currentOrder.size
            ) /* then */ isCorrect = true;

        return isCorrect;
    }

    public void PrintDetails(string text)
    {
        if (nameBox) nameBox.text = "Customer";
        if (dialogBox) dialogBox.text = text;
        
    }
}


[System.Serializable]
class RandDialogs
{
    public string[] intros;
    public string[] outros;
}