using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewScroll : MonoBehaviour {

    public float maxScale;
    public float minScale;
    float currentScale;

    void Update() {
        //dividieren für besser interpolation
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float increment) {
        currentScale += increment;
        if (currentScale >= maxScale)
        {
            currentScale = maxScale;
        }
        else if (currentScale <= minScale)
        {
            currentScale = minScale;
        }
        this.gameObject.GetComponent<RectTransform>().transform.localScale = new Vector3(currentScale, currentScale, 1);
    }

}
