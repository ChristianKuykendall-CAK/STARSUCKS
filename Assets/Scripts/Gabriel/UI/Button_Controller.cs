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

    private bool isFirstPress = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent = GetComponentInChildren<TMP_Text>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isInteractable)
            textComponent.rectTransform.position = startPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isInteractable)
        {
            if (isFirstPress) {
                startPos = textComponent.rectTransform.position;
                downPos = startPos + Vector3.up * -textDownAmt;
                isFirstPress = false;
            }
            textComponent.rectTransform.position = downPos;
        }       
    }
}
