using UnityEngine;

public class DoorController : MonoBehaviour
{

    public Transform door1;
    public Transform door2;
    private BoxCollider2D detection;
    private Quaternion door1StartRotation;
    private Quaternion door2StartRotation;
    private bool doorOpen = false;
    // Start is called once before the fir
    // st execution of Update after the MonoBehaviour is created
    void Start()
    {
        detection = GetComponent<BoxCollider2D>();
        door1StartRotation = door1.rotation;
        door2StartRotation = door2.rotation;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Patient"))
        {
            Debug.Log("Patient Touched Doors");
            if (collision.transform.position.y > gameObject.transform.position.y && !doorOpen)
            {
                //Rotating Doors
                //Quaternion door1end = new Quaternion(0f, 0f, -45f, 0f);
                //Quaternion door2end = new Quaternion(0f, 0f, 45f, 0f);
                //door1.rotation = Quaternion.Lerp(door1StartRotation, door1end, );
                //door2.rotation = Quaternion.Lerp(door2StartRotation, door2end, );
                doorOpen = true;
            }
            if (collision.transform.position.y < gameObject.transform.position.y && !doorOpen)
            {
                ////Rotating Doors
                //Quaternion door1end = new Quaternion(0f, 0f, 45f, 0f);
                //Quaternion door2end = new Quaternion(0f, 0f, -45f, 0f);
                //door1.rotation = Quaternion.Lerp(door1StartRotation, door1end, 5f);
                //door2.rotation = Quaternion.Lerp(door2StartRotation, door2end, 5f);

                door1.position = Vector2.Lerp(door1.position, , 0.5f);
                door2.position = Vector2.Lerp(door1.position, door2.position, 0.5f);

                doorOpen = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Patient"))
        {
            Quaternion.Lerp(door1.rotation, door1StartRotation, .5f);
            Quaternion.Lerp(door2.rotation, door2StartRotation, .5f);
        }
        doorOpen = false;
    }
}
