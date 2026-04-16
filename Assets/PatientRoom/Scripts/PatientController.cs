using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    public static PatientController selectedPatient;
    public bool isSelected = false;

    private Transform patient;
    private Quaternion origRot;
    public int speed = 10;
    public float angle = 15f;
    private string comments;

    //Head Stuff
    public SpriteRenderer patient_eyes;
    public SpriteRenderer patient_mouth;
    public SpriteRenderer patient_frontHair;
    public SpriteRenderer patient_backHair;

    //Quirks
    public bool isNervous;
    public bool isPainResistant;
    public string patientName;

    //Game Values
    public float nervousness;
    public float bloodAmount;
    public string bloodType;
    public static int InstanceCount { get; set; }

    private void Start()
    {
        patient = gameObject.GetComponent<Transform>();
        origRot = patient.rotation;
    }
    private void OnMouseDown()
    {

        if (selectedPatient == null)
        {
            Select();
        }
        else
        {
            selectedPatient.Deselect();
        }

    }

    void Select()
    {
        selectedPatient = this;
        FormController.instance.FillForm(this);
        isSelected = true;
        // Optional: notify UI / info panel
        Debug.Log($"{name} selected");


    }
    void Deselect()
    {
        selectedPatient = null;
        FormController.instance.ClearForm();
        isSelected = false;
        Debug.Log($"{name} deselected");
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

    

    private void OnEnable()
    {
        InstanceCount++;
        Debug.Log($"{gameObject.name} spawned. Total: {InstanceCount}");
    }

    public void RemovePatient()
    {
        Destroy(selectedPatient.gameObject);
        InstanceCount = Mathf.Max(0, InstanceCount - 1);
        Debug.Log($"{gameObject.name} removed. Total: {InstanceCount}");
    }
}
