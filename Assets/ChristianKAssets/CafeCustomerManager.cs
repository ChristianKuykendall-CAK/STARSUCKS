using UnityEngine;

/**
 * This script is made to have hardcoded values for the customers that come in for each day
 * The special characters will have to have their own section
 */

public class CafeCustomerManager : MonoBehaviour
{
    public static CafeCustomerManager instance;

    int[] daycycle = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }


    void CustomersForTheDay()
    {
        OrderManager.instance.GenerateNewOrder();
        daycycle[0]++;
    }
}
