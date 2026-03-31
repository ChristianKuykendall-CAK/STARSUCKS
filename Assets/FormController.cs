using UnityEngine;

public class FormController : MonoBehaviour
{

    private Transform formTransform;
    private Vector3 origPos;
    private Quaternion origRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origPos = formTransform.position;
        origRot = formTransform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePage()
    {
        formTransform.position = Vector3.Lerp(origPos, new Vector3(origPos.x - 10f, origPos.y, origPos.z), 2f);
        formTransform.rotation = Quaternion.Lerp(origRot, new Quaternion(0,0,0,0), 2f);
    }
    void RemovePage()
    {
        formTransform.position = Vector3.Lerp(formTransform.position, origPos, 2f);
        formTransform.rotation = Quaternion.Lerp(formTransform.rotation, origRot, 2f);
    }

}
