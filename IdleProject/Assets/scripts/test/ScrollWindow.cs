using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollWindow : MonoBehaviour {

    public GameObject prefab;
    public int quantity;

	// Use this for initialization
	void Start () {
        Populate();
	}
	
	void Populate () {
        for(int i = 0; i < quantity; i++)
        {
            GameObject newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV();
        }
	}
}
