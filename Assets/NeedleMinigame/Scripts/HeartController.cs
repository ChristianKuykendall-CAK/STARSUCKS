using UnityEngine;
using UnityEngine.InputSystem;

public class HeartController : MonoBehaviour
{
    private Transform tf;
    private bool canMove;
    private float fillSpeed;
    public float speed;
    private Rigidbody2D rb;
    public GameObject vial;
    public GameObject mouth;
    public GameObject eyes;
    public Sprite[] mouthSprites;
    public Sprite[] eyeSprites;


    private void Awake()
    {
        fillSpeed = 0.01f;
        tf = transform;
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void OnEnable()
    {
        canMove = true;
    }

    private void OnDisable()
    {
        canMove = false;
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
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f);
                rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            }
            vial.GetComponent<BloodController>().fillRate = fillSpeed;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Yellow"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[0];
            fillSpeed = .05f;
        }
        else if (collision.CompareTag("Green"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[1];
            fillSpeed = .1f;
        }
        else if (collision.CompareTag("Red"))
        {
            mouth.GetComponent<SpriteRenderer>().sprite = mouthSprites[2];
            fillSpeed = .01f;
        }
    }

}
