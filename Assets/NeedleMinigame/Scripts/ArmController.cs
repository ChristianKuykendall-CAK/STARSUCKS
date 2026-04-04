using UnityEngine;

public class ArmController : MonoBehaviour
{
    private Transform tf;
    public float amplitude = .5f;
    public float frequency = 1f;
    public float timeOffset = 1f;
    public float speed = 1.0f;
    private Vector2 origPos;
    public GameObject needle;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();
        origPos = tf.position;        
    }

    // Update is called once per frame
    void Update()
    {
        
        float t = Time.time * frequency + timeOffset;
        float x = (Mathf.PerlinNoise(t, 0f) * 2f - 1f) * amplitude;
        float y = (Mathf.PerlinNoise(0f, t) * 2f - 1f) * amplitude;

        if (!needle.GetComponent<NeedleController>().needleDrop)
        {
            Vector2 offset = new Vector2(x, y);
            Vector2 targetPos = origPos + offset;
            transform.localPosition = Vector2.Lerp(tf.localPosition, targetPos, t);
        }
    }


}
