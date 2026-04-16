using UnityEngine;
using UnityEngine.UI;

public class TempButtonController : MonoBehaviour
{
    public CoffeeOptions.Temps tempVal;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => CoffeeBuilder.instance.SetTemp(tempVal));
    }
}
