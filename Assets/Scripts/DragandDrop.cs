using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragandDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private RectTransform rectTransform;
    public string cupSnap;

    public float snapDistance = 80f;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();

        rb.useGravity = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject snapPoint = GameObject.Find(cupSnap);

        if (snapPoint != null)
        {
            float distance = Vector2.Distance(rectTransform.position, snapPoint.transform.position);
            
            if (distance < snapDistance)
            {
                rectTransform.position = snapPoint.transform.position;
                transform.SetParent(snapPoint.transform);
            }
        }

        rb.useGravity = true;
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
