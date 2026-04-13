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

    // This is invoked after the last day to get an ending
    void EndGame()
    {
        if (G1 < 3 || G2 < 3 || G3 < 3 || G4 < 3)
        {
            //Call the default last scene
            //be friends will all of the girls
        }
        else
        {
            int[] points = { G1, G2, G3, G4 };

            int highest = Mathf.Max(points);

            int countHighest = 0;
            int winnerIndex = -1;

            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] == highest)
                {
                    countHighest++;
                    winnerIndex = i;
                }
            }

            if (countHighest > 1)
            {
                Debug.Log("It's a tie!");
                // Handle tie ending here
                // example G1 had 4 and G2 had 4
            }
            else
            {
                // some bs comment
                Debug.Log("Winner is G" + (winnerIndex + 1));

                switch (winnerIndex)
                {
                    case 0:
                        // G1 ending
                        break;
                    case 1:
                        // G2 ending
                        break;
                    case 2:
                        // G3 ending
                        break;
                    case 3:
                        // G4 ending
                        break;
                }
            }
        }
    }
}
