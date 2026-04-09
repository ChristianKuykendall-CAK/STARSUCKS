using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("(SS)Backstory");
    }
    public void CreditScene()
    {

    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        // Stops play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quits the application (build)
        Application.Quit();
#endif
    }
}
