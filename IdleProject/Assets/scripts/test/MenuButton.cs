using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {

    public GameObject box;

    public void CallBox() {
        box.GetComponent<BoxBounce>().BoxCall();
    }
}
