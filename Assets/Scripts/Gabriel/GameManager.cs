using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int currentDay;
    private float[] girlPoints = {0, 0, 0};
    
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
}
