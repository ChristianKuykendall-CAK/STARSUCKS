using UnityEngine;
using UnityEngine.UI;

public class ToppingsButton : MonoBehaviour
{
    public CoffeeOptions.Toppings topping;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => CoffeeBuilder.instance.SetTopping(topping));
    }
}
