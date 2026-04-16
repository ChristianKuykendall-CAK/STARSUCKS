using UnityEngine;
using UnityEngine.UI;

public class CafeTutorial : MonoBehaviour
{
    public GameObject[] parts;
    int counter = 0;
    bool tutorialFinished = false;
    public GameObject MainGame;

    public void NextStep()
    {
        if (counter < parts.Length)
        {
            Debug.Log(counter);

            parts[counter].gameObject.SetActive(false);
            counter++;
            if (counter < parts.Length)
            {
                parts[counter].gameObject.SetActive(true);
            }
        }
    }
    public void FinishTutorial()
    {
        NextStep();
        tutorialFinished = true;
        MainGame.gameObject.SetActive(true);
    }
}
