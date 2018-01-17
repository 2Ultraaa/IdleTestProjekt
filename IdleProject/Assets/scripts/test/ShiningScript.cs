using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiningScript : MonoBehaviour {

    public float time;
    [RangeAttribute(1f, 10f)]
    public float loopTime;

    GameObject shineMask;
    GameObject shine;
    Vector3 startPos;
    Vector3 endPos;

	void Start () {
        shineMask = this.gameObject;
        shine = shineMask.transform.Find("ShineImg").gameObject;
        shine.GetComponent<RectTransform>().sizeDelta = new Vector2(100, shineMask.GetComponent<RectTransform>().rect.width * Mathf.Sqrt(2f));
        shine.transform.rotation = Quaternion.Euler(0, 0, -60);

        startPos = new Vector3(0, 0 - shineMask.GetComponent<RectTransform>().rect.height * 2, 0);
        endPos = new Vector3(0, 0 + shineMask.GetComponent<RectTransform>().rect.height * 2, 0);

        shine.GetComponent<RectTransform>().transform.localPosition = startPos;

        StartCoroutine(myShine(startPos, endPos, time));
	}

    IEnumerator myShine(Vector3 sPos, Vector3 ePos, float seconds) {
        while (true)
        {
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / seconds;
                shine.transform.localPosition = Vector3.Lerp(sPos, ePos, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(loopTime);
        }
    }
}
