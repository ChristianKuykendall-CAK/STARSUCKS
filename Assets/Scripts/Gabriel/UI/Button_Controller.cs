using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Controller : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float textDownAmt = 12;
    TMP_Text textComponent;
    Vector3 startPos;
    Vector3 downPos;
    public bool isInteractable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent = GetComponentInChildren<TMP_Text>();

        startPos = textComponent.rectTransform.position;
        downPos = startPos + Vector3.up * -textDownAmt;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        textComponent.rectTransform.position = startPos;
        Debug.Log("Button released!");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInteractable)
            textComponent.rectTransform.position = downPos;
    }
}
