using UnityEngine;
using UnityEngine.UI;


public class pppoopoo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CoffeeBuilder.instance.bloodI=gameObject.GetComponent<Image>();
    }

}
