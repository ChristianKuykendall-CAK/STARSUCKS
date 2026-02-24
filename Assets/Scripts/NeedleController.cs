using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NeedleController : MonoBehaviour
{

    public Transform shadow;
    public float detectRange = 1000f;
    private Rigidbody2D rb;
    public LayerMask armLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("DropNeedle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, detectRange, armLayer);
        if (hit)
        {
            shadow.position = hit.point;
            shadow.gameObject.SetActive(true);
        }
        else
        {
            shadow.gameObject.SetActive(false);
        }
        Debug.DrawRay(rb.position, Vector2.down, Color.red, 10f);

    }

    IEnumerator DropNeedle()
    {
        rb.gravityScale = -2;
        rb.linearVelocity = new Vector2(0, 5);
        yield return new WaitForSeconds(2f);
        rb.gravityScale = 100;
        rb.linearVelocity = new Vector2(0, -5);
        yield return new WaitForSeconds(1f);
        rb.gravityScale = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Vein"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;

            Debug.Log("You've hit the vein!");
        }
    }

    void CheckGrounded()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        //shadow.gameObject.SetActive(!); //Only show if not grounded
    }
}
