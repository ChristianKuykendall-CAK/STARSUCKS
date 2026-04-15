using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

[System.Serializable]
public class Coffee
{
    [SerializeField] private CoffeeOptions.Temps _temp;
    public CoffeeOptions.Temps temp { get { return _temp; } set { _temp = value; } }
    [SerializeField] private CoffeeOptions.BloodTypes _bloodType;
    public CoffeeOptions.BloodTypes bloodType { get { return _bloodType; } set { _bloodType = value; } }
    [SerializeField] private CoffeeOptions.Toppings _topping;
    public CoffeeOptions.Toppings topping { get { return _topping; } set { _topping = value; } }
    [SerializeField] private CoffeeOptions.Sizes _size;
    public CoffeeOptions.Sizes size { get { return _size; } set { _size = value; } }

    public bool hasCoffee;

    public Coffee()
    {
        _temp = 0;
        _bloodType = 0;
        _topping = 0;
        _size = 0;
        hasCoffee = false;
    }

    public static Coffee Randomize(Coffee coffee)
    {
        int randTemp = Random.Range(1, CoffeeOptions.temps.Length);
        coffee.temp = (CoffeeOptions.Temps)randTemp;

        int randBloodType = Random.Range(1, CoffeeOptions.bloodTypes.Length);
        coffee.bloodType = (CoffeeOptions.BloodTypes)randBloodType;
        
        int randToppping = Random.Range(0, CoffeeOptions.toppings.Length);
        coffee.topping = (CoffeeOptions.Toppings)randToppping;
        
        int randSize = Random.Range(1, CoffeeOptions.sizes.Length);
        coffee.size = (CoffeeOptions.Sizes)randSize;

        return coffee;
    }

    public string GetPrintDetails()
    {
        string sizeDisplay = ToDisplayString(size);
        string tempDisplay = ToDisplayString(_temp);
        string bloodTypeDisplay = _bloodType.ToString().Replace("plus", "+").Replace("minus", "-");
        string toppingDisplay = ToDisplayString(topping);

        return $"Coffee Details:\nSize: {sizeDisplay}\nTemp: {tempDisplay}\nBlood Type: {bloodTypeDisplay}\nTopping: {toppingDisplay}";
    }

    public static string ToDisplayString(System.Enum value)
    {
        string raw = value.ToString();

        // Add space before capital letters
        string withSpaces = Regex.Replace(raw, "(\\B[A-Z])", " $1");

        return withSpaces.ToLower();
        // Capitalize first letter
        // return char.ToUpper(withSpaces[0]) + withSpaces.Substring(1);
    }

    public static string ReplaceSymbols(System.Enum value)
    {
        string stringToChange =  value.ToString();
        stringToChange = stringToChange.Replace("plus", "+");
        stringToChange = stringToChange.Replace("minus", "-");

        // Capitalize first letter
        return stringToChange;
    }

}
