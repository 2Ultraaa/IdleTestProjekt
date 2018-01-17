using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTouch : MonoBehaviour {
    //checkt wann der bildschirm wo berührt wurde
    public GameObject touchIcon;

    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).position;
            touchIcon.GetComponent<TouchIcon>().CreateIcon(touchDeltaPosition);
            Debug.Log(touchDeltaPosition);
        }
    }
}
