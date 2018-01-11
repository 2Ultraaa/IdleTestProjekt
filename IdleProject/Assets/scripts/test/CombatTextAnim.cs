using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextAnim : MonoBehaviour
{

    public GameObject CBT_prefab;
    public GameObject parent;
    public string CBT_text;
    public Color color;
    public float durationMove;
    public float durationFade;
    public float moveDistance;
    [RangeAttribute(0f, 30f)]
    public float deviation;
    Vector3 startPos;
    Vector3 endPos;

    private void Start() {
        startPos = parent.transform.localPosition;
        endPos = new Vector3(parent.transform.localPosition.x, parent.transform.localPosition.y + moveDistance, 0);
        CBT_prefab.GetComponent<Text>().color = color;
    }

    public void ShowCombatText() {
        initCBT(CBT_text);
    }

    private void initCBT(string text) {
        GameObject temp = Instantiate(CBT_prefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();

        temp.transform.SetParent(parent.transform);

        tempRect.transform.localPosition = parent.transform.localPosition;
        tempRect.transform.localScale = parent.transform.localScale;
        tempRect.transform.localRotation = parent.transform.localRotation;

        temp.GetComponent<Text>().text = text;
        temp.SetActive(true);

        endPos[0] += Random.Range (-1 * deviation, deviation);

        StartCoroutine(FadeIn(temp, durationFade));
        StartCoroutine(Move(startPos, endPos, durationMove, temp));
        StartCoroutine(FadeOut(temp, durationFade));

        endPos[0] = parent.transform.localPosition.x;

        Destroy(temp.gameObject, durationMove + durationMove/2);
    }

    IEnumerator Move(Vector3 sPos, Vector3 ePos, float seconds, GameObject obj) {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            obj.transform.localPosition = Vector3.Lerp(sPos, ePos, Mathf.SmoothStep(0f, 1f, t));
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator FadeIn(GameObject obj, float seconds) {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            obj.GetComponent<Text>().color = new Color(color[0], color[1], color[2], t);
            yield return null;
        }
    }

    IEnumerator FadeOut(GameObject obj, float seconds) {
        yield return new WaitForSeconds(durationMove);
        float t = 1f;
        while (t >= 0f)
        {
            t -= Time.deltaTime / seconds;
            obj.GetComponent<Text>().color = new Color(color[0], color[1], color[2], t);
            yield return null;
        }
    }
}
