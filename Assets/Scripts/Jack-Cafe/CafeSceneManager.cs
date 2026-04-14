using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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
    public GameObject customerImageObject;
    public GameObject choiceButtonContainer;
    public Button createButton;
    public Button serveButton;

    [Header("Girls")]
    public Girl[] girls;

    [Header("Customer")]
    public string randCustomerNamePlaceholder = "Customer";
    public Sprite randCustomerImage;
    public RectTransform customerEnterPoint;
    public RectTransform customerOrderPoint;
    public RectTransform customerExitPoint;
    public float typingSpeed = 1;

    [Header("Gameplay Variables")]
    public int numRandOrdersBetweenGirls = 2;
    private TMP_Text _dialogText;
    private TMP_Text _nameText;
    private TMP_Text _orderPaperText;
    private Queue dailyEvents;
    private int currentGirlIndex;
    private Image _customerImage;
    private RectTransform _customerImageTransform;
    private Coroutine currentlyTyping;


    
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

        _customerImage = customerImageObject.GetComponent<Image>();
        _customerImageTransform = customerImageObject.GetComponent<RectTransform>();

        GenerateDailyEvents();

        BeginNextEvent();
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

    public void BeginNextEvent()
    {
        StartCoroutine("NextEvent");
    }

    private IEnumerator NextEvent()
    {
        if (_customerImage.sprite != null) yield return StartCoroutine("CustomerExit");

        if ((bool)dailyEvents.Dequeue()) {
            yield return StartCoroutine(CustomerEnter(randCustomerImage));
            DisplayCustomerName();
            orderManager.GenerateNewOrder();
        }
        else {
            ToggleButtonsActive();
            yield return StartCoroutine(CustomerEnter(girls[currentGirlIndex].sprite));
            DisplayCurrentGirlName();
            inkManager.DisplayDialog(currentGirlIndex);
            orderManager.SetOrderByGirlIndex(currentGirlIndex);
            currentGirlIndex++;
        }
    }

    public void ToggleButtonsActive()
    {
        createButton.interactable = !createButton.interactable;
        createButton.GetComponent<Button_Controller>().isInteractable = createButton.interactable;

        serveButton.interactable = !serveButton.interactable;
        serveButton.GetComponent<Button_Controller>().isInteractable = serveButton.interactable;
    }

    public IEnumerator CustomerEnter(Sprite sprite)
    {
        _customerImage.sprite = sprite;

        float i = 0;
        while (i <= 1) {
            Vector3 currentPos = Vector3.Lerp(customerEnterPoint.position, customerOrderPoint.position, i);

            _customerImageTransform.position = currentPos;

            i += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator CustomerExit()
    {
        float i = 0;
        while (i <= 1) {
            Vector3 currentPos = Vector3.Lerp(customerOrderPoint.position, customerExitPoint.position, i);

            _customerImageTransform.position = currentPos;

            i += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void DisplayDialog(string newDialogText)
    {
        if (currentlyTyping != null) StopCoroutine(currentlyTyping);
        currentlyTyping = StartCoroutine(TypeDialog(newDialogText));
    }

    private IEnumerator TypeDialog(string text)
    {
        string outputString = "";

        foreach (char c in text)
        {
            outputString += c;

            _dialogText.text = outputString;

            yield return new WaitForSeconds(0.05f / typingSpeed);
        }

        currentlyTyping = null;
        if (_nameText.text != randCustomerNamePlaceholder) inkManager.ShowProgressionOption();
    }

    public void DisplayCustomerName()
    {
        _nameText.text = randCustomerNamePlaceholder;
    }

    public void DisplayCurrentGirlName()
    {
        _nameText.text = girls[currentGirlIndex].name;
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
        choiceButtonContainer.SetActive(false);
    }

    public void SwitchBlood()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(true);
        normalCafe.SetActive(false);
        paperOrder.SetActive(true);
        dialogTextBox.SetActive(false);
        nameTextBox.SetActive(false);
        choiceButtonContainer.SetActive(false);
    }

    public void SwitchToCafe()
    {
        cupSize.SetActive(false);
        bloodToppings.SetActive(false);
        normalCafe.SetActive(true);
        paperOrder.SetActive(false);
        dialogTextBox.SetActive(true);
        nameTextBox.SetActive(true);
        choiceButtonContainer.SetActive(true);
    }
}

[System.Serializable]
public class Girl
{
    public string name;
    public Sprite sprite;
}