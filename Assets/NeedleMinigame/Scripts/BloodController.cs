using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
    private Slider slider;
    private float minValue;
    public float drainRate = .01f;
    public float bloodAmount;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        slider = GetComponent<Slider>();
        minValue = slider.minValue;
    }

    void Start()
    {
        StartCoroutine(Drain());
    }

    IEnumerator Drain()
    {
        while (slider.value > minValue)
        {
            slider.value -= drainRate;
            yield return new WaitForSeconds(.1f);
        }
    }

    
}
