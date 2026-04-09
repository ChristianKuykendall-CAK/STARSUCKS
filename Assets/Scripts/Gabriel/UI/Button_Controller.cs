using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Button buttonComponent;
    TMP_Text textComponent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonComponent = GetComponent<Button>();
        textComponent = GetComponentInChildren<TMP_Text>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textComponent.alignment = TextAlignmentOptions.Top;
        Debug.Log("Button released!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        textComponent.alignment = TextAlignmentOptions.Bottom;
    }
}
