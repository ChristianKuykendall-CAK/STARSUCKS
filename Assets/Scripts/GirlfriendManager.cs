using UnityEngine;

public class GirlfriendManager : MonoBehaviour
{
    public static GirlfriendManager instance;

    int G1;
    int G2;
    int G3;
    int G4;


    void Awake()
    {
        // 1. Check if an instance already exists
        if (instance != null && instance != this)
        {
            // 2. If it does, destroy this new one to prevent duplicates
            Destroy(gameObject);
            return;
        }

        // 3. If it doesn't, set this as the instance and make it persistent
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        G1 = 0;
        G2 = 0;
        G3 = 0;
        G4 = 0;
    }

    public void G1Point()
    {
        G1++;
    }
    public void G2Point()
    {
        G2++;
    }
    public void G3Point()
    {
        G3++;
    }
    public void G4Point()
    {
        G4++;
    }
}
