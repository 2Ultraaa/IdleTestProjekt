using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIdleObject : MonoBehaviour {

    //script liegt noch auf dem button
    public GameObject prefabListContent;
    [RangeAttribute(1, 50)]
    public int contentNr;
    GameObject idleObj;

	void Start () {
        //lese prefab ein
		idleObj = GameObject.Instantiate(Resources.Load("prefab_obj") as GameObject);
    }

    //funktion für den button
    public void initAddIdle() {
        AddIdle(contentNr);
    }

	void AddIdle (int contentNr) {
        //erstelle idle prefab
        GameObject newIdle = Instantiate(idleObj) as GameObject;
        newIdle.transform.SetParent(prefabListContent.transform, false);

        for(int i = 0; i < contentNr; i++)
        {
            //fülle prefab mit x image-prefabs
            GameObject content = GameObject.Instantiate(Resources.Load("content") as GameObject);
            content.transform.SetParent(newIdle.transform.Find("prefab_main").transform.Find("prefab_main_img").transform.Find("prefab_main_content").transform, false);
        }
	}
}
