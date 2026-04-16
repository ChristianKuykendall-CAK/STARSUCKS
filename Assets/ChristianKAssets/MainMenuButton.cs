using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour,
    // Interfaces that detect mouse input
    // In this case it is specifically used for detecting the
    // mouse hovering over the buttons in the UI
    IPointerEnterHandler, 
    IPointerExitHandler
{
    public Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " Hover Enter");
        animator.SetBool("Hovering", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + " Hover Exit");
        animator.SetBool("Hovering", false);
    }
}
