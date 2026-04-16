using UnityEngine;

public class ZoneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float moveSpeed = 200f;
    public float changeDirTime = 1f;

    private float timer;
    private float direction;
    private Rigidbody2D zone;

    void Awake()
    {
        zone = GetComponent<Rigidbody2D>();
        PickDirection();
    }

    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            PickDirection();

        zone.linearVelocity = Vector2.up * direction * moveSpeed * Time.deltaTime;
    }

    void PickDirection()
    {
        timer = Random.Range(0.3f, changeDirTime);
        direction = Random.Range(-1f, 1f);
    }



}
