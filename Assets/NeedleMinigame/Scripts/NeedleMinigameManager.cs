using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeedleMinigameManager : MonoBehaviour
{
    public static NeedleMinigameManager instance = null;
    private int chances = 3;
    private bool needleHit = false;
    private string bloodMinigame;
    private float nervousness;
    private float bloodAmount;


    //public Animator sceneAnim;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetNervousness(float amount)
    {
        nervousness = amount;
    }
    
    public float GetNervousness()
    {
        return nervousness;
    }
    public void SetTotalBlood(float amount)
    {
        bloodAmount += amount;
    }

    public float GetTotalBlood()
    {
        return bloodAmount;
    }

    public void DecreaseChances()
    {
        --chances;
    }

    public int GetChances()
    { 
        return chances;
    }

    public void GoToBloodMinigame()
    {
        SceneManager.LoadSceneAsync(bloodMinigame);
    }
}
