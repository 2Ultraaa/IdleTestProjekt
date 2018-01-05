using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {

    public GameObject CBT_prefab;
    public string CBT_text;
    
    // Use this for initialization
    public void ShowCombatText () {
        initCBT(CBT_text);
	}
	
	private void initCBT(string text)
    {
        GameObject temp = Instantiate(CBT_prefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(FindObjectOfType<Canvas>().transform);
        tempRect.transform.localPosition = CBT_prefab.transform.localPosition;
        tempRect.transform.localScale = CBT_prefab.transform.localScale;
        tempRect.transform.localRotation = CBT_prefab.transform.localRotation;

        temp.GetComponent<Text>().text = text;
        temp.SetActive(true);
        temp.GetComponent<Animator>().SetTrigger("Hit");
        Destroy(temp.gameObject, 2);
    }
}
