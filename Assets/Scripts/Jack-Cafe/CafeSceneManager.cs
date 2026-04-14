using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using Ink.Runtime;

public class CafeSceneManager : MonoBehaviour
{
    public static CafeSceneManager instance;

    [Header("Text references")]
    public GameObject dialogTextBox;
    public GameObject nameTextBox;
    public GameObject orderPaperTextBox;

    [Header("Scene Elements")]
    public OrderManager orderManager;
    public InkManager inkManager;
    public GameObject cupSize;
    public GameObject bloodToppings;
    public GameObject normalCafe;
    public GameObject paperOrder;

    [Header("Gameplay Variables")]
    public int numRandOrdersBetweenGirls = 2;

    private TMP_Text _dialogText;
    private TMP_Text _nameText;
    private TMP_Text _orderPaperText;
    private Queue dailyEvents;
    private int currentGirlIndex;


    
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    
    void Start()
    {
        orderManager.LoadJSONData();

        _dialogText = dialogTextBox.GetComponentInChildren<TMP_Text>();
        _nameText = nameTextBox.GetComponentInChildren<TMP_Text>();
        _orderPaperText = orderPaperTextBox.GetComponentInChildren<TMP_Text>();

        dailyEvents = new Queue();

        GenerateDailyEvents();

        NextEvent();
    }

    void GenerateDailyEvents()
    {
        int girlsAddedCounter = 0;

        while (girlsAddedCounter < 3)
        {
            for (int i = 0; i < numRandOrdersBetweenGirls; i++)
            {
                // Push true if random order
                dailyEvents.Enqueue(true);
            }
            // Push false if main girl encounter
            dailyEvents.Enqueue(false);

            girlsAddedCounter++;
        }
    }

    public void NextEvent()
    {
        if ((bool)dailyEvents.Dequeue()) {
            orderManager.GenerateNewOrder();
        }
        else {
            inkManager.DisplayDialog();
            orderManager.SetOrderByGirlIndex(currentGirlIndex);
            currentGirlIndex++;
        }
    }

    public void DisplayDialog(string newDialogText)
    {
        _dialogText.text = newDialogText;
    }

    public void DisplayName(string newNameText)
    {
        _nameText.text = newNameText;
    }

    public void DisplayPaperOrder(string newOrderText)
    {
        _orderPaperText.text = newOrderText;
    }

    public void SwitchToppings()
    {
        cupSize.SetActive(true);
        bloodToppings.SetActive(false);
        normalCafe.SetActive(false);
        paperOrder.SetActive(true);
        dialogTextBox.SetActive(false);
        nameTextBox.SetActive(false);
    }

    public void SwitchBlood()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(true);
        normalCafe.SetActive(false);
        paperOrder.SetActive(true);
        dialogTextBox.SetActive(false);
        nameTextBox.SetActive(false);
    }

    public void SwitchToCafe()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(false);
        normalCafe.SetActive(true);
        paperOrder.SetActive(false);
        dialogTextBox.SetActive(true);
        nameTextBox.SetActive(true);
    }
}
