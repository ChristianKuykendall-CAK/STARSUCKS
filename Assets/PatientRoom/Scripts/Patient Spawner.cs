using System.Collections;
using Unity.Mathematics;
using UnityEngine;
//using System;

public class PatientSpawner : MonoBehaviour
{
    public static PatientSpawner instance;

    public Sprite[] eyes;
    public Sprite[] mouths;
    public Sprite[] frontHairs;
    public Sprite[] backHairs;
    public string[] firstName;
    public string[] lastName;


    public GameObject patientPrefab;
    public int maxPatients = 5;
    public int currentPatientCount = 0;
    public float spawnInterval = 5;
    public float offset = 0;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        instance.StopAllCoroutines();
        instance.StartCoroutine(SpawnPatients());
    }
    public void ResetCount()
    {
        instance.offset = 0;
        PatientController.InstanceCount = 0;
        instance.currentPatientCount = 0;
        Debug.Log("Count Reset");
        instance.StartCoroutine(SpawnPatients());
    }

    IEnumerator SpawnPatients()
    {
        instance.offset += 1.5f;
        while (PatientController.InstanceCount < instance.maxPatients)
        {
            instance.Spawn();
            instance.currentPatientCount++;
            yield return new WaitForSeconds(instance.spawnInterval);
        }
        instance.offset = 0;
    }

    void Spawn()
    {
        System.Random random = new System.Random();
        PatientSpawner.instance.offset += 1.5f;

        float amountBlood = UnityEngine.Random.Range(50f, 300f);
        string[] bloodType = {"AB+", "AB-", "AB", "A+", "A-", "A", "B+", "B-", "B", "O+", "O-", "O" };
        int eye = random.Next(0, eyes.Length);
        int mouth = random.Next(0, mouths.Length);
        int frontHair = random.Next(0, frontHairs.Length);
        int backHair = random.Next(0, backHairs.Length);
        int first = random.Next(0, firstName.Length);
        int last = random.Next(0, lastName.Length);
        int blood = random.Next(0, bloodType.Length);

        GameObject instance = Instantiate(patientPrefab, transform.position + new Vector3(offset,0,0), Quaternion.identity);
        instance.GetComponent<PatientController>().patient_eyes.sprite = eyes[eye];
        instance.GetComponent<PatientController>().patient_mouth.sprite= mouths[mouth];
        instance.GetComponent<PatientController>().patient_frontHair.sprite = frontHairs[frontHair];
        instance.GetComponent<PatientController>().patient_backHair.sprite = backHairs[backHair];
        instance.GetComponent<PatientController>().patientName = (firstName[first]+ " " + lastName[last]);
        instance.GetComponent<PatientController>().bloodType = bloodType[blood];

        instance.GetComponent<PatientController>().bloodAmount = amountBlood;
        //Gameplay aspects based on appearance
        instance.GetComponent<PatientController>().nervousness = 2;
        if (eye == 4)
        {
            instance.GetComponent<PatientController>().nervousness += 5;
        }
        if (mouth == 3)
        {
            instance.GetComponent<PatientController>().nervousness += 5;
        }
        if (mouth == 4)
        {
            instance.GetComponent<PatientController>().nervousness = 0;
        }
    }
}
