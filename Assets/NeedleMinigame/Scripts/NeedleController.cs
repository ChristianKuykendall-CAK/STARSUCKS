using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class NeedleController : MonoBehaviour
{

    public Transform shadow;
    public float detectRange = 1000f;
    private Rigidbody2D rb;
    public LayerMask armLayer;
    public Transform posA;
    public Transform posB;
    private Vector2 pointA;
    private Vector2 pointB;
    public float speed = 1.0f;
    public bool needleDrop = false;
    private Vector3 origPos;
    public ChanceScript chances;
    public GameObject failureScreen;
    public GameObject curtain;
    public GameObject hitEffect;

    
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origPos = gameObject.transform.position;
        pointA = new Vector2(posA.position.x, posA.position.y);
        pointB = new Vector2(posB.position.x, posB.transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        failureScreen.SetActive(false);
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

        //Moves back and forth
        if (!needleDrop)
        {
            float t = Mathf.PingPong(Time.fixedTime * speed, 1f);
            float s = t * t * (3f - 2f * t);
            transform.position = Vector2.Lerp(pointA, pointB, s);
        }
    }

    IEnumerator DropNeedle()
    {
        rb.linearVelocity = Vector2.zero;
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
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            Debug.Log("You've hit the vein!");

            StartCoroutine(BeginBloodExtraction());
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            NeedleMinigameManager.instance.DecreaseChances();
            StartCoroutine("ResetNeedle");
            Debug.Log("You've missed the vein!");
        }
    }
    void OnJump()
    { 
        needleDrop = true;
        StartCoroutine("DropNeedle");
    }
    void CheckGrounded()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        //shadow.gameObject.SetActive(!); //Only show if not grounded
    }
    IEnumerator ResetNeedle()
    {
        int numChances = NeedleMinigameManager.instance.GetChances();
        if(numChances > 0)
        {
            chances.UpdateHearts(numChances);
            yield return new WaitForSeconds(2f);
            gameObject.transform.position = origPos;
            rb.constraints = RigidbodyConstraints2D.None;
            needleDrop = false;
        }
        else
        {
            failureScreen.SetActive(true);
        }

    }
    IEnumerator BeginBloodExtraction()
    {
        yield return new WaitForSeconds(2f);
        curtain.GetComponent<CurtainController>().CurtainMove();
    }

    IEnumerator HitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(4f);
        hitEffect.SetActive(false);
    }
}
