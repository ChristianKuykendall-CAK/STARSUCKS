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
    public GameObject goToCafe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        slider = GetComponent<Slider>();
        maxValue = slider.maxValue;
    }
    private void OnEnable()
    {
        goToCafe.SetActive(false);
        bloodAmount = FormController.instance.patientBloodAmount;
        StartCoroutine(Fill());
    }

    private void OnDisable()
    {
        StopCoroutine(Fill());
    }

    IEnumerator Fill()
    {
        while (slider.value < maxValue)
        {
            slider.value += fillRate;
            yield return new WaitForSeconds(.1f);
        }
        success.SetActive(true);
        NeedleMinigameManager.instance.SetTotalBlood(bloodAmount);
        text.text = "You extracted all the blood! \nAmount Extracted: " + bloodAmount + "\nTotal Extracted: " + NeedleMinigameManager.instance.GetTotalBlood();
        if(NeedleMinigameManager.instance.GetTotalBlood() > 500)
        {
            text.text += "\nYou've collected enough blood! Head to the cafe when you're ready!";
            goToCafe.SetActive(true);
        }
    }
}
