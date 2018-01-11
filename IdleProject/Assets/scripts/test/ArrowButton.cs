using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowButton : MonoBehaviour
{

    public GameObject prefab;
    [RangeAttribute(1, 4)]
    public int myCase;

    GameObject obj;
    GameObject arrow;
    bool isActive;

    private void Start() {
        isActive = false;
        obj = this.gameObject;
    }

    //weise button ArrowToggle zu, beim ersten klicken CallArrow, beim zweiten klicken DestroyArrow
    public void ArrowToggle() {
        if(isActive == false)
        {
            isActive = !isActive;
            CallArrow();
        } else
        {
            isActive = !isActive;
            DestroyArrow();
        }
    }

    void CallArrow() {
        arrow = Instantiate(prefab) as GameObject;
        arrow.transform.SetParent(FindObjectOfType<Canvas>().transform, false);
        arrow.GetComponent<ArrowTransform>().ArrowPlacement(obj, myCase);
        arrow.transform.SetParent(obj.transform);
    }

    void DestroyArrow() {
        arrow.GetComponentInChildren<ArrowAnim>().DestroyThis();
        Destroy(arrow, 1);
    }
}
