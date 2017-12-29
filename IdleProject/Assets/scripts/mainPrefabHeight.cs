using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainPrefabHeight : MonoBehaviour {

    public GameObject mainPrefab;
    private float height;
    private float contentCount;
    private int lineCount;
    private float widthRatio;
    private float contentHeight;
    private float contentWidth;
    public GameObject objGrid;
    
	void Start () {
        //die breite des kontents ist die breite des objekts, auf dem das grid layout liegt
        contentWidth = objGrid.GetComponent<RectTransform>().sizeDelta[0];

        //die objekte in den prefabs müssen das tag "PrefabContent" haben, funktioniert bisher nur für ein prefab
        contentCount = GameObject.FindGameObjectsWithTag("PrefabContent").Length;

        //funktioniert nur für den fall, dass 4 zellen eine zeile bilden und dabei 3 mal das spacing benutzt wird
        //zahl der inhalte * zellengröße + benutzte spacings + für jede neue zeile padding left & right geteilt durch gegebene kontentbreite
        widthRatio = ((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % 4) + (Mathf.Floor(contentCount / 4) * 3)) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount / 4) * (objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left)) / contentWidth;

        //wenn nicht anders angegeben nur eine zeile kontent
        lineCount = 1;

        /* DEBUGS
        Debug.Log(height);
        Debug.Log(contentCount);
        Debug.Log(contentWidth);
        Debug.Log((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % 4) + (Mathf.Floor(contentCount/4)*3)) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount/4)*(objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left));
        Debug.Log(((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % 4) + (Mathf.Floor(contentCount / 4) * 3)) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount / 4) * (objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left)) / contentWidth);
        */
        
        //umsetzten des verhältnisses in höhe
        for (int i = 0; widthRatio > 1.0; i++)
        {
            lineCount += 1;
            widthRatio -= 1f;
        }
        //Debug.Log(lineCount);

        //zeilenzahl * zellgröße + benutzte spacings + padding bottom & top
        height += (lineCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[1]) + ((lineCount - 1) * objGrid.GetComponent<GridLayoutGroup>().spacing[1]) + objGrid.GetComponent<GridLayoutGroup>().padding.bottom + objGrid.GetComponent<GridLayoutGroup>().padding.top;

        //Debug.Log(height);

        mainPrefab.GetComponent<LayoutElement>().minHeight = height;
        mainPrefab.GetComponent<LayoutElement>().preferredHeight = height;
    }
}
