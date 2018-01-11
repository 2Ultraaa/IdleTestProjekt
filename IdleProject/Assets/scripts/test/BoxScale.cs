using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BoxScale : MonoBehaviour {

    //lege dieses script auf den click me button 
    //wahrscheinlich werden später die buttons zum togglen zwei unterschiedliche sein
    public GameObject boxPrefab;
    [RangeAttribute(0f, 0.1f)]
    public float scaleTime;

    GameObject box;
    GameObject bg;
    RectTransform boxRect;
    bool trigger;

	void Start () {
        box = boxPrefab.transform.Find("Box").gameObject;
        bg = boxPrefab.transform.Find("bg").gameObject;
        boxRect = box.GetComponent<RectTransform>();
        boxRect.transform.localPosition = Vector3.zero;

        //trigger toggle
        trigger = false;
        boxPrefab.SetActive(false);
    }

    IEnumerator LerpScale(float time) {
        //während der animation ist der button nicht bedienbar
        if (trigger == false)
        {
            this.gameObject.GetComponent<Button>().interactable = false;

            float t = 0f;
            Vector3 origScale = box.transform.localScale;
            Vector3 targetScale = origScale + new Vector3(0.05f, 0.05f, 0);

            //hoch skalieren
            while (t <= 1f)
            {
                t += Time.deltaTime / time;
                box.transform.localScale = Vector3.Lerp(origScale, targetScale, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }

            //zurück skalieren
            t = 0;
            while (t <= 1f)
            {
                t += Time.deltaTime / time;
                box.transform.localScale = Vector3.Lerp(targetScale, origScale, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }

            trigger = !trigger;
            this.gameObject.GetComponent<Button>().interactable = true;
        }
        else if (trigger == true)
        {
            //fade out soll langsamer sein, d. h. sichtbarer
            StartCoroutine(Beenden(scaleTime * 2));
        }
    }

    IEnumerator FadeIn(float seconds) {
        float t = 0f;
        while (t <= 1f)
        {
            t += Time.deltaTime / seconds;
            bg.GetComponent<Image>().color = new Color(0, 0, 0, t / 2);
            yield return null;
        }
    }

    IEnumerator Beenden(float seconds) {
        //box verschwindet bevor bg sich ausfadet
        box.SetActive(false);
        //bg fadeout
        float t = 1f;
        while (t >= 0f)
        {
            t -= Time.deltaTime / seconds;
            bg.GetComponent<Image>().color = new Color(0, 0 ,0 , t / 2);
            yield return null;
        }

        trigger = !trigger;
        //deaktivieren des prefabs, resetten des box-objekts
        boxPrefab.SetActive(false);
        box.SetActive(true);
    }

    public void CallScale() {
        boxPrefab.SetActive(true);
        //fade in soll langsamer sein, d. h. sichtbarer
        StartCoroutine(FadeIn(scaleTime * 2));
        StartCoroutine(LerpScale(scaleTime));
    }
}
