using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchIcon : MonoBehaviour {

    public float time;

    public void CreateIcon(Vector2 touchPos) {
        //aktiviert das objekt
        //damit es jedes mal erst nach time sekunden deaktiviert wird, wird es hier am anfang geresettet
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = new Vector3(touchPos.x, touchPos.y, 0);
        StartCoroutine(InitDestroy());
    }

    public void DestroyIcon() {
        //deaktiviert das objekt nach time sekunden
        this.gameObject.SetActive(false);
    }

    IEnumerator InitDestroy() {
        yield return new WaitForSeconds(time);
        DestroyIcon();
    }
}
