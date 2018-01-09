using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAnim : MonoBehaviour {

    public GameObject arrowObj;
    public float wiggleDist;
    public float durationMove;
    private Vector3 startPos;
    private Vector3 endPos;

	void Start () {
        //objekt muss mit noch ausgeblendet und zerstört werden, bestenfalls an ein if gekoppelt
        //start position ist an der stelle an der das parent sich befindet, end position ist um wiggleDist in der y-achse verschoben
        startPos = arrowObj.transform.localPosition; 
        endPos = new Vector3(arrowObj.transform.localPosition.x + wiggleDist, arrowObj.transform.localPosition.y, 0);

        StartCoroutine(FadeIn());
        StartCoroutine(Move(startPos, endPos, durationMove));
	}

    public void DestroyThis() {
        StartCoroutine(FadeOut());
    }

    IEnumerator Move(Vector3 sPos, Vector3 ePos, float seconds) {
        //loopt zwischen start position und endposition
        while (true)
        {
            //zur endposition
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / seconds;
                arrowObj.transform.localPosition = Vector3.Lerp(sPos, ePos, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }
            //zur startposition
            t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / seconds;
                arrowObj.transform.localPosition = Vector3.Lerp(ePos, sPos, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }
        }
    }

    IEnumerator FadeIn() {
        //fade in
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            arrowObj.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator FadeOut() {
        //fade out
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            arrowObj.GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

}
