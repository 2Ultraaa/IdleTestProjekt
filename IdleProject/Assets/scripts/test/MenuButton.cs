using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
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
        //skalierung ist anscheinend periodischer localScale wert, d. h. bei .9f .9999999999999999f = 1
        arrow.GetComponent<RectTransform>().localScale = new Vector3(.9f, .9f, .9f);
        arrow.transform.SetParent(FindObjectOfType<Canvas>().transform);
        arrow.GetComponent<ArrowTransform>().myStuff(obj, myCase);
    }

    void DestroyArrow() {
        arrow.GetComponentInChildren<ArrowAnim>().DestroyThis();
        Destroy(arrow, 1);
    }
}
