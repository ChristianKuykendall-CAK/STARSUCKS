using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SSSceneManager.instance.GoToCurrentScene();
    }

    public void CreditScene()
    {
        // TODO: Make credit panel on main menu scene and toggle it.
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
