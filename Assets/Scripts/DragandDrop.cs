using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private float startGravityScale;

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
        // Debug.Log(eventData.delta);
        // rb.MovePosition(rectTransform.anchoredPosition + eventData.delta);

        // Vector2 direction = (Vector2)rectTransform.position - Mouse.current.position.ReadValue();
        // direction.Normalize();
        // rb.AddForce(direction * 100);

        rb.MovePosition(Mouse.current.position.ReadValue());
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // GameObject snapPoint = GameObject.Find(cupSnap);

        // if (snapPoint != null)
        // {
        //     float distance = Vector2.Distance(rectTransform.position, snapPoint.transform.position);

        //     Debug.Log(distance);
            
        //     if (distance < snapDistance)
        //     {
        //         rb.AddForce(snapPoint.transform.position);
        //         transform.SetParent(snapPoint.transform);
        //     }
        // }

        rb.gravityScale = startGravityScale;
    }

    // void OnTriggerEnter(Collider other) // player hits the pickups
    // {

    //     if (other.gameObject.CompareTag("pickUp"))
    //     {
    //         other.gameObject.SetActive(false);
    //         stockCount = stockCount + 1;
    //         Objectives();

    //     }


    // }
}
