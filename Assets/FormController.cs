using TMPro;
using UnityEngine;

public class FormController : MonoBehaviour
{
    public static FormController instance;

    private Transform formTransform;
    public Transform viewSpot;
    private Vector3 origPos;
    private Quaternion origRot;

    public TMP_Text nameText;
    public TMP_Text bloodTypeText;



    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        formTransform = GetComponent<Transform>();
        origPos = formTransform.position;
        origRot = formTransform.rotation;
    }

    public void FillForm(PatientController patient)
    {
        nameText.text = patient.patientName;
        bloodTypeText.text = patient.bloodType;
    }

    public void MovePage()
    {
        formTransform.position = viewSpot.position;
        formTransform.rotation = viewSpot.rotation;
        //formTransform.position = Vector3.Lerp(formTransform.position, viewSpot.position, 2f);
        //formTransform.rotation = Quaternion.Lerp(formTransform.rotation, viewSpot.rotation, 2f);
    }
    public void RemovePage()
    {
        formTransform.position = origPos;
        formTransform.rotation = origRot;
        //formTransform.position = Vector3.Lerp(viewSpot.position, origPos, 2f);
        //formTransform.rotation = Quaternion.Lerp(viewSpot.rotation, origRot, 2f);
    }

}
