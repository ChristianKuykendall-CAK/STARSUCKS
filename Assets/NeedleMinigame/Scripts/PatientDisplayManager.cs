using UnityEngine;

public class PatientDisplayManager : MonoBehaviour
{

    public SpriteRenderer mouth;
    public SpriteRenderer eyes;
    public SpriteRenderer frontHair;
    public SpriteRenderer backHair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frontHair.sprite = FormController.instance.patientFrontHair;
        backHair.sprite = FormController.instance.patientBackHair;
    }
}
