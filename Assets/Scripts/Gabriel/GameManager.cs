using Unity.XR.GoogleVr;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Girl[] girls;

    private int currentDay;
    
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentDay = 1;
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }

    public void GoToNextScene(bool progressDay = false)
    {
        if (progressDay) {
            currentDay++;
            // TODO go to blood drive.
            Debug.Log("Go to blood drive");
        }
        else
        {
            // TODO go to cafe scene.
            Debug.Log("Go to the cafe");
        }
    }
}

[System.Serializable]
public class Girl
{
    public string name;
    public bool nameKnown;
    public int lovePoints;
    public Sprite sprite;
}