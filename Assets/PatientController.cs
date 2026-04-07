using System.Collections;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    public bool isSelected = false;
    public string patientName;
    public string bloodType;
    private Transform patient;
    private Quaternion origRot;
    public int speed = 10;
    public float angle = 15f;

    //Head Stuff
    public SpriteRenderer patient_eyes;
    public SpriteRenderer patient_mouth;
    public SpriteRenderer patient_frontHair;
    public SpriteRenderer patient_backHair;



    private void Start()
    {
        patient = gameObject.GetComponent<Transform>();
        origRot = patient.rotation;
    }
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

     void Update()
    {
        if (!isSelected) 
        { 
            //wobble
            float zOffset = Mathf.Sin(Time.time * speed) * angle;
            patient.rotation = Quaternion.Euler(0, 0, origRot.z + zOffset);
        }
        else
        {
            patient.rotation = origRot;
        }
    }
}
