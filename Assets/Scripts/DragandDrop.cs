using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private float startGravityScale;
    private bool snapped = false;

    public string cupSnap;
    public float snapDistance = 80f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startGravityScale = rb.gravityScale;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();

        rb.gravityScale = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!snapped) {
            rb.MovePosition(Mouse.current.position.ReadValue());
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject snapPoint = GameObject.Find(cupSnap);

        if (snapPoint != null)
        {
            float distance = Vector2.Distance(rectTransform.position, snapPoint.transform.position);
            
            if (distance < snapDistance)
            {
                snapped = true;
                rb.simulated = false;
                GetComponent<Image>().raycastTarget = false;

                CoffeeBuilder.instance.snappedObjCount++;
                
                rectTransform.position = snapPoint.transform.position;
                transform.SetParent(snapPoint.transform);
            }
        }
        else rb.gravityScale = startGravityScale;
    }
}
