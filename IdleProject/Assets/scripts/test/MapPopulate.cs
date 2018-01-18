using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPopulate : MonoBehaviour {

    //lege script auf map content
    GameObject MapContent;
    float mySize;

    //besiedlungsobjekt
    public GameObject prefab;

    //map ist immer potenz aus 2
    [RangeAttribute(0, 30)]
    public int baseTwo;
    public float size;

    public int populateNr;

	void Start () {
        MapContent = this.gameObject;
        MapContent.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);

        //maximaler abstand zum mittelpunkt ist gesamte größe der karte / 2 - breite eines der platzierten objekte, damit es nicht über den rand kommt /2 (fall für quadratische objekte)
        mySize = size / 2 - prefab.GetComponent<RectTransform>().rect.width / 2;

        //rufe createpopulation so oft auf, wie populateNr
        for (int i = 0; i < populateNr; i++)
        {
            CreatePopulation();
        }

        //initialisiere occlusion extension, gebe den namen des scrollrects der map an
        GameObject.Find("ScrollMap").GetComponent<UnityEngine.UI.Extensions.UI_ScrollRectOcclusion>().Init();
    }
	
	void CreatePopulation () {
        Vector3 position = new Vector3(Random.Range(-1 * mySize, mySize), Random.Range(-1 * mySize, mySize), 0);

        GameObject tempObj = Instantiate(prefab) as GameObject;
        tempObj.transform.SetParent(MapContent.transform);
        tempObj.transform.localPosition = position;

    }

    private void OnValidate() {
        size = Mathf.Pow(2, baseTwo);
    }
}
