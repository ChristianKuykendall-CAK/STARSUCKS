using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using System;

public class PatientSpawner : MonoBehaviour
{
    public Sprite[] eyes;
    public Sprite[] mouths;
    public Sprite[] frontHairs;
    public Sprite[] backHairs;
    public string[] firstName;
    public string[] lastName;
    public string[] bloodType;


    public GameObject patientPrefab;
    public int maxPatients = 5;
    private int currentPatientCount = 0;
    public float spawnInterval = 5;
    private float offset = 0;


    void Start()
    {
        offset = 0;
        StartCoroutine(SpawnPatients());
    }

    IEnumerator SpawnPatients()
    {
        while( currentPatientCount < maxPatients)
        {
            Spawn();
            currentPatientCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
        offset = 0;
    }

    void Spawn()
    {
        System.Random random = new System.Random();
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
        offset += 1f;
    }
}
