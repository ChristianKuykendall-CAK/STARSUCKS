using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Girl[] girls;
    
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