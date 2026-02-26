using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToWaitingRoom() // aka MainScene
    {
        SceneManager.LoadScene(0);
    }

    public void ToToppings() // aka toppings
    {
        SceneManager.LoadScene(1);
    }
    
    public void ToBlood()
    {
        SceneManager.LoadScene(2);
    }

    public void ToCafe()
    {
        SceneManager.LoadScene(3);
    }

    public void ToDrawing()
    {
        SceneManager.LoadScene(4);
    }

    public void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    
}
