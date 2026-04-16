using UnityEngine;
using UnityEngine.SceneManagement;

public class SSSceneManager : MonoBehaviour
{
    public static SSSceneManager instance;

    public string[] sceneNames = { "(SS)MainMenu", "(SS)Backstory", "PatientRoom", "Cafe", "EndScene" };
    public int[] sceneOrder = { 1, 2, 3, 2, 3, 2, 3, 4 };
    public int currentSceneindex = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(instance);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(sceneNames[0]);
    }

    public void GoToCurrentScene()
    {
        SceneManager.LoadScene(sceneNames[currentSceneindex]);
    }

    public void GoToNextScene()
    {
        SceneManager.LoadScene(sceneNames[++currentSceneindex]);
    }

    public void GoToSceneAtIndex(int index)
    {
        SceneManager.LoadScene(sceneNames[index]);
    }

    public int GetCurrentDay()
    {
        return currentSceneindex % 2;
    }
}
