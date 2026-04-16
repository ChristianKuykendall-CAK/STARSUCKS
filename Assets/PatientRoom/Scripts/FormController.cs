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
    public TMP_Text commentsText;

    //Values for minigame
    private float patientNervousness;
    public float patientBloodAmount;
    private string patientBloodType;

    public Sprite patientFrontHair;
    public Sprite patientBackHair;

    public GameObject spawner; 

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
        MovePage();
        nameText.text = patient.patientName;
        bloodTypeText.text = patient.bloodType;
        patientBloodAmount = patient.bloodAmount;
        //hints about nervousness
        if (!patient.isSelected)
        {
            if (patient.nervousness == 0)
            {
                commentsText.text += "Nonchalant about it.\n";
            }
            else if (patient.nervousness >= 1 && patient.nervousness < 5)
            {
                commentsText.text += "A bit nervous about it.\n";
            }
            else if (patient.nervousness >= 5 && patient.nervousness < 10)
            {
                commentsText.text += "Pretty nervous about it.\n";
            }
            else
            {
                commentsText.text += "Freaking out about it.\n";
            }

            //hints about blood amount
            if (patientBloodAmount < 100)
            {
                commentsText.text += "A disappointing source of blood.\n";
            }
            else if (patientBloodAmount >= 100 && patientBloodAmount < 200)
            {
                commentsText.text += "A good source of blood.\n";
            }
            else
            {
                commentsText.text += "An excellent source of blood.\n";
            }
        }
        NeedleMinigameManager.instance.SetNervousness(patient.nervousness);
        patientFrontHair = patient.patient_frontHair.sprite;
        patientBackHair = patient.patient_backHair.sprite;
    }

    public void ClearForm()
    {
        RemovePage();
        commentsText.text = string.Empty;
        NeedleMinigameManager.instance.SetNervousness(0);
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
