using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;

public class EnumMove : MonoBehaviour
{
    public float delayTime;
    public float finishTime;
    public Transform endPoint;
    private Vector3 minScale;
    private Vector3 maxScale;
    void Start()
    {
        minScale = new Vector3(0.55f, 0.55f, 1f);
        maxScale = new Vector3(2f, 2f, 1f);
        StartCoroutine (MoveOverSeconds (gameObject, endPoint.position, finishTime));
        StartCoroutine(ScaleOverSecond(minScale, maxScale, finishTime));

    }
    
    public IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
    {
        yield return new WaitForSeconds(delayTime);
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }

    public IEnumerator ScaleOverSecond(Vector3 min, Vector3 max, float seconds)
    {
        yield return new WaitForSeconds(delayTime);
        float i = 0.0f;
        while (i < seconds)
        {
            i += Time.deltaTime;
            transform.localScale = Vector3.Lerp(min, max, i/seconds);
            yield return null;
        }
    }
}