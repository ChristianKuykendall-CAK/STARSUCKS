using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

[System.Serializable]
public class Coffee
{
    public CoffeeOptions.Temps temp;
    public CoffeeOptions.BloodTypes bloodType;
    public CoffeeOptions.Toppings topping;
    public CoffeeOptions.Sizes size;

    public Coffee()
    {
        temp = 0;
        bloodType = 0;
        topping = 0;
        size = 0;
    }

    public static Coffee Randomize(Coffee coffee)
    {
        int randTemp = Random.Range(0, CoffeeOptions.temps.Length);
        coffee.temp = (CoffeeOptions.Temps)randTemp;

        int randBloodType = Random.Range(0, CoffeeOptions.bloodTypes.Length);
        coffee.bloodType = (CoffeeOptions.BloodTypes)randBloodType;
        
        int randToppping = Random.Range(0, CoffeeOptions.toppings.Length);
        coffee.topping = (CoffeeOptions.Toppings)randToppping;
        
        int randSize = Random.Range(0, CoffeeOptions.sizes.Length);
        coffee.size = (CoffeeOptions.Sizes)randSize;

        return coffee;
    }

    public void PrintDetails(TMP_Text log = null)
    {
        string tempDisplay = ToDisplayString(temp);
        string bloodTypeDisplay = bloodType.ToString().Replace("plus", "+").Replace("minus", "-");
        string toppingDisplay = ToDisplayString(topping);
        string sizeDisplay = ToDisplayString(size);

        if (log)
        {
            log.text = $"Coffee Details:\nTemp: {tempDisplay}\nBlood Type: {bloodTypeDisplay}\nTopping: {toppingDisplay}\nSize: {sizeDisplay}";
        }

        Debug.Log(tempDisplay);
        Debug.Log(bloodTypeDisplay);
        Debug.Log(toppingDisplay);
        Debug.Log(sizeDisplay);
    }

    public static string ToDisplayString(System.Enum value)
    {
        string raw = value.ToString();

        // Add space before capital letters
        string withSpaces = Regex.Replace(raw, "(\\B[A-Z])", " $1");

        // Capitalize first letter
        return char.ToUpper(withSpaces[0]) + withSpaces.Substring(1);
    }
}
