using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{

    public GameObject creditPanel;

    private bool credit_opened = false;

    public void StartGame()
    {
        SSSceneManager.instance.GoToCurrentScene();
    }

    public void CreditScene()
    {
        // TODO: Make credit panel on main menu scene and toggle it.
        //Done by Christian A :]
        if (credit_opened == false)
        {
            credit_opened = true;
            creditPanel.SetActive(true);
        }
        else if (credit_opened == true)
        {
            credit_opened = false;
            creditPanel.SetActive(false);
        }

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
