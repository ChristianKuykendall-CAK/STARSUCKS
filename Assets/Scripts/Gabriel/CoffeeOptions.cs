using System;

public class CoffeeOptions
{
    public enum Temps
    {
        hot, cold
    }
    public enum BloodTypes
    {
        Aplus, Aminus, Bplus, Bminus, ABplus, ABminus, Oplus, Ominus
    }
    public enum Toppings
    {
        none, whippedCream, sprinkles
    }
    public enum Sizes
    {
        small, medium, large
    }
    
    public static Temps[] temps = (Temps[])Enum.GetValues(typeof(Temps));
    public static BloodTypes[] bloodTypes = (BloodTypes[])Enum.GetValues(typeof(BloodTypes));
    public static Toppings[] toppings = (Toppings[])Enum.GetValues(typeof(Toppings));
    public static Sizes[] sizes = (Sizes[])Enum.GetValues(typeof(Sizes));
}