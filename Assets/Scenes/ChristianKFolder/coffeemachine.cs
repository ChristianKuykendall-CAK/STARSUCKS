using UnityEngine;

public class coffeemachine : MonoBehaviour
{
    public GameObject coffeecup;
    Vector2 newPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newPosition = new Vector2(0f, -1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveLeft()
    {
        if (coffeecup.transform.position.x > -7f)
        {
            newPosition.x = newPosition.x - 3.5f;
            coffeecup.transform.position = newPosition;
        }
    }
    public void MoveRight()
    {
        if (coffeecup.transform.position.x < 7f) { 
            newPosition.x = newPosition.x + 3.5f;
            coffeecup.transform.position = newPosition;
        }
    }
}
