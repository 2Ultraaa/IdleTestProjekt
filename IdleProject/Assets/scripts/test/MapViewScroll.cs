using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapViewScroll : MonoBehaviour {

    public float maxScale;
    public float minScale;
    public float zoomSpeed;
    public float resetDuration;

    Canvas canvas;
    float startScale;
    float currentScale;

    private void Start() {
        canvas = FindObjectOfType<Canvas>();
        startScale = canvas.scaleFactor;
    }

    void Update() {
        // Mausbedienung
        Zoom(Input.GetAxis("Mouse ScrollWheel"));

        // If there are two touches on the device...
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
        {
            GameObject.Find("ScrollMap").GetComponent<ScrollRect>().enabled = false;
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if (currentScale != maxScale || currentScale != minScale)
            {
                Zoom(-1 * deltaMagnitudeDiff * zoomSpeed);
            }
        }

        if ((Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(1).phase == TouchPhase.Ended))
        {
            GameObject.Find("ScrollMap").GetComponent<ScrollRect>().enabled = true;
        }
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
        canvas.scaleFactor = currentScale;
    }

}
