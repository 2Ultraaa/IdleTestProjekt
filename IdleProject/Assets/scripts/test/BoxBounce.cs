using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxBounce : MonoBehaviour {

    public Canvas canvas;
    public GameObject box;
    public GameObject button;
    public float time;

    RectTransform canvasTrans;
    Vector3 startPos;
    Vector3 endPos;
    bool trigger;


	void Start () {
        //startposition ist immer eine screenlänger unterhalb des canvas, endposition immer in der mitte des canvas
        canvasTrans = canvas.GetComponent<RectTransform>();
        startPos = new Vector3(0, -1 * canvasTrans.rect.height, 0);
        endPos = Vector3.zero;

        //trigger toggle
        trigger = false;

        //zu beginn ist die box immer ausserhalb des canvas
        box.SetActive(false);
        box.GetComponent<RectTransform>().transform.localPosition = startPos;
    }

    IEnumerator Move(Vector3 sPos, Vector3 ePos, float seconds) {
        //wenn außerhalb des canvas, während animation button nicht bedienbar
        if (trigger == false) {
            //schiebt hoch
            button.GetComponent<Button>().interactable = false;
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / seconds;
                box.transform.localPosition = Vector3.Lerp(sPos, ePos, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }
            trigger = !trigger;
            button.GetComponent<Button>().interactable = true;
        }
        //wenn innterhalb des canvas, während animation button nicht bedienbar
        else if (trigger == true)
        {
            //schiebt runter
            button.GetComponent<Button>().interactable = false;
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / seconds;
                box.transform.localPosition = Vector3.Lerp(ePos, sPos, Mathf.SmoothStep(0f, 1f, t));
                yield return new WaitForFixedUpdate();
            }
            trigger = !trigger;
            button.GetComponent<Button>().interactable = true;
        }
    }

    //schiebe box nach oben
    public void BoxCall () {
        box.SetActive(true);
        StartCoroutine(Move(startPos, endPos, time));
    }
}
