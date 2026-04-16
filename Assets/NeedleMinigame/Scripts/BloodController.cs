using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
    private Slider slider;
    private float maxValue;
    public float fillRate = .01f;
    public float bloodAmount;
    public GameObject success;
    public TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        slider = GetComponent<Slider>();
        maxValue = slider.maxValue;
    }
    private void OnEnable()
    {
        StartCoroutine(Fill());
    }

    private void OnDisable()
    {
        StopCoroutine(Fill());
    }

    private void Update()
    {

    }

    IEnumerator Fill()
    {
        while (slider.value < maxValue)
        {
            slider.value += fillRate;
            yield return new WaitForSeconds(.1f);
        }
        success.SetActive(true);
        text.text = "You extracted all the blood!";
    }
}
