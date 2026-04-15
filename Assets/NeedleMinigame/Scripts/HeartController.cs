using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class HeartController : MonoBehaviour
{
    private Transform tf;
    private bool canMove;
    private PlayerInput pi;
    public float speed;
    private Rigidbody2D rb;
    public GameObject mouth;
    public GameObject eyes;
    public Sprite[] mouthSprites;
    public Sprite[] eyeSprites;


    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
        tf = transform;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        canMove = true;
    }

    private void FixedUpdate()

    {
        //Vector3 vector = Vector3.zero;

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    vector = Vector3.up;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    vector = Vector3.down;
        //}
        //else
        //{
        //    vector = Vector3.zero;
        //}
        //rb.linearVelocity = vector*speed;
        //Debug.Log(vector);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Yellow"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[0];
        }
        else if (collision.CompareTag("Green"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[1];
        }
        else if (collision.CompareTag("Red"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[2];
        }
    }

}
