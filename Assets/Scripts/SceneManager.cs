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

    public void ToCoffee() // aka toppings
    {
        SceneManager.LoadScene(1);
    }
    
    public void ToBlood()
    {
        SceneManager.LoadScene(2);
    }

    public void ToDrawing()
    {
        SceneManager.LoadScene(4);
    }

    public void ToWaitingRoom() // aka MainScene
    {
        SceneManager.LoadScene(0);
    }
}
