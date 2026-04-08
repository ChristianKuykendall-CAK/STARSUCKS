using UnityEngine;
using UnityEngine.SceneManagement;

public class ClinicManager : MonoBehaviour
{
    public static ClinicManager instance;
    public Scene bloodExtractionScene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToNeedleMinigame()
    {
        Debug.Log("ClickDetected");
        SceneManager.LoadScene("NeedleMinigame");
    }
    public void MoveToPatientRoom()
    {
        Debug.Log("ClickDetected");
        SceneManager.LoadScene("PatientRoom");
    }
    public void MoveToBloodExtraction()
    {
        Debug.Log("ClickDetected");
        SceneManager.LoadScene("BloodExtraction");
    }
}
