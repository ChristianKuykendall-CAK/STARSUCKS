using UnityEngine;
using UnityEngine.UI;

public class Blood_Button_Controller : MonoBehaviour
{

    private Button button;
    public CoffeeOptions.BloodTypes bloodType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => CoffeeBuilder.instance.SetBloodType(bloodType));
    }
}
