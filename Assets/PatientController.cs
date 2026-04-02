using UnityEngine;

public class PatientController : MonoBehaviour
{
    private bool isSelected = false;
    public string patientName;
    public string bloodType;

    private void OnMouseDown()
    {
        isSelected = !isSelected;
        if (isSelected)
        {
            FormController.instance.FillForm(this);
            FormController.instance.StartCoroutine("MovePage");
        }
        else
        {
            FormController.instance.StartCoroutine("RemovePage");
        }
    }
}
