using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CurtainController : MonoBehaviour
{
    private RectTransform tf;
    private Vector3 origPos;
    public RectTransform newPos;
    public AnimationCurve curve;
    public int moveSpeed;

    public GameObject[] bloodObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tf = GetComponent<RectTransform>();
        origPos = tf.position;
        Debug.Log(origPos);
    }

    public void CurtainMove()
    {
        StartCoroutine(MoveCurtain());
    }


    void OnDisable()
    {
        foreach (GameObject obj in bloodObjects)
        {
            obj.SetActive(true);
        }
    }
    // Update is called once per frame
    IEnumerator MoveCurtain()
    {
        float distance = Vector3.Distance(origPos, newPos.position);
        float remainingDistance = distance;

        while (remainingDistance > 0)
        {
            tf.position = Vector3.Lerp(origPos, newPos.position, curve.Evaluate(1- (remainingDistance/distance)));
            remainingDistance -= moveSpeed * Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
    }

    //IEnumerator ReplaceCurtain()
    //{
    //    float distance = Vector3.Distance(newPos.position, origPos);
    //    float remainingDistance = distance;

    //    while (remainingDistance > 0)
    //    {
    //        tf.position = Vector3.Lerp(newPos.position, origPos, curve.Evaluate(1 - (remainingDistance / distance)));
    //        remainingDistance -= moveSpeed * Time.deltaTime;
    //        yield return null;
    //    }
    //}

}
