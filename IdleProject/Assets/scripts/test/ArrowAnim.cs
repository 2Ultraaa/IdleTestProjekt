using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAnim : MonoBehaviour {

    public GameObject arrowObj;
    public float wiggleDist;
    public float durationMove;

    [RangeAttribute(0f, 1f)]
    public float durationFade;
    private Vector3 startPos;
    private Vector3 endPos;

	void Start () {
        //objekt muss mit noch ausgeblendet und zerstört werden, bestenfalls an ein if gekoppelt
        //start position ist an der stelle an der das parent sich befindet, end position ist um wiggleDist in der y-achse verschoben
        startPos = Vector3.zero; 
        endPos = new Vector3(0 + wiggleDist, 0, 0);

        StartCoroutine(FadeIn(durationFade));
        StartCoroutine(Move(startPos, endPos, durationMove));
	}

    public void DestroyThis() {
        StartCoroutine(FadeOut(durationFade));
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

    IEnumerator FadeIn(float seconds) {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            arrowObj.GetComponent<Image>().color = new Color(1, 1, 1, t);
            yield return null;
        }
    }

    IEnumerator FadeOut(float seconds) {
        float t = 1f;
        while (t >= 0f)
        {
            t -= Time.deltaTime / seconds;
            arrowObj.GetComponent<Image>().color = new Color(1, 1, 1, t);
            yield return null;
        }
    }

}
