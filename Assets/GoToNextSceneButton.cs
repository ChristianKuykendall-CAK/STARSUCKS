using UnityEngine;
using UnityEngine.UI;

public class GoToNextSceneButton : MonoBehaviour
{
    Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => SSSceneManager.instance.GoToNextScene());
    }



}
