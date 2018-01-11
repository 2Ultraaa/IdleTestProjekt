using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitShowArrow : MonoBehaviour {

    public bool testbool;

	void Start () {
        //objekt auf das gezeigt werden soll, switch case variabel 1 ↓; 2 ←; 3 ↑; 4 →
        ShowArrow(FindObjectOfType<Canvas>().transform.Find("Point2This").gameObject, 2);

        if (testbool == false)
        {
            DelArrow(FindObjectOfType<Canvas>().transform.Find("Point2This").gameObject);
        }
    }

    void ShowArrow (GameObject obj, int myCase) {
        obj.AddComponent<ArrowButton>();
        obj.GetComponent<ArrowButton>().myCase = myCase;
        //resultiert in einem klon in der szene
        obj.GetComponent<ArrowButton>().prefab = GameObject.Instantiate(Resources.Load("ArrowTransform") as GameObject);
        obj.GetComponent<Button>().onClick.AddListener(obj.GetComponent<ArrowButton>().ArrowToggle);
    }

    void DelArrow (GameObject obj) {
        //löscht onclick funktion, auf button liegendes script und referenz pfeil
        obj.GetComponent<Button>().onClick.RemoveListener(obj.GetComponent<ArrowButton>().ArrowToggle);
        Destroy(obj.GetComponent<ArrowButton>());
        Destroy(GameObject.Find("ArrowTransform(Clone)"), 0);
    }
}
