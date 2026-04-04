using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject cupSize;
    public GameObject bloodToppings;
    public GameObject normalCafe;
    public GameObject paperOrder;
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

    public void SwitchToppings()
    {
        cupSize.SetActive(true);
        bloodToppings.SetActive(false);
        normalCafe.SetActive(false);
        paperOrder.SetActive(true);
    }

    public void SwitchBlood()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(true);
        normalCafe.SetActive(false);
        paperOrder.SetActive(true);

    }

    public void SwitchToCafe()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(false);
        normalCafe.SetActive(true);
        paperOrder.SetActive(false);
    }
    
}
