using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainPrefabHeight : MonoBehaviour {

    //mainPrefab ist das "main" modul im eigentlichen prefab (neben header und footer)
    //objGrid ist das Objekt in der hierachie mit dem grid component (prefab_main_content)
    public GameObject mainPrefab;
    public GameObject objGrid;

    private float height;
    private float contentCount;
    private int lineCount;
    private float lineWidth;
    private int lineObjects;
    private float widthRatio;
    private float contentWidth;
    
	void Start () {        

        //die breite des kontents ist die breite des objekts, auf dem das grid layout liegt
        contentWidth = objGrid.GetComponent<RectTransform>().sizeDelta[0];

        //die transforms des objGrid und deren childs werden gezählt, also menge der content objekte = alle transforms - das des parents
        contentCount = objGrid.GetComponentsInChildren<Transform>().Length - 1;

        //berechnen wie viele objekte sich in einer reihe maximal befinden, spacing ist zahl der objekte - 1
        lineWidth = objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left;
        while (lineWidth < contentWidth)
        {
            if (lineWidth + objGrid.GetComponent<GridLayoutGroup>().cellSize[0] <= contentWidth)
            {
                lineWidth += objGrid.GetComponent<GridLayoutGroup>().cellSize[0];
                lineObjects++;
            }
            else { break; }

            if ((lineWidth + objGrid.GetComponent<GridLayoutGroup>().spacing[0]) < contentWidth)
            {
                lineWidth += objGrid.GetComponent<GridLayoutGroup>().spacing[0];
            }
        }

        //zahl der inhalte * zellengröße + benutzte spacings + für jede neue zeile padding left & right geteilt durch gegebene kontentbreite
        widthRatio = ((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % lineObjects) + (Mathf.Floor(contentCount / lineObjects) * (lineObjects - 1))) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount / lineObjects) * (objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left)) / contentWidth;

        //wenn nicht anders angegeben nur eine zeile kontent
        lineCount = 1;
        
        /* DEBUGS
        Debug.Log(lineWidth);
        Debug.Log(lineObjects);       
        Debug.Log(height);
        Debug.Log(contentCount);
        Debug.Log(contentWidth);
        Debug.Log((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % lineObjects) + (Mathf.Floor(contentCount/lineObjects)*(lineObjects-1))) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount/lineObjects)*(objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left));
        Debug.Log(((contentCount * objGrid.GetComponent<GridLayoutGroup>().cellSize[0]) + (((contentCount % lineObjects) + (Mathf.Floor(contentCount / lineObjects) * (lineObjects-1))) * objGrid.GetComponent<GridLayoutGroup>().spacing[0]) + Mathf.Floor(contentCount / lineObjects) * (objGrid.GetComponent<GridLayoutGroup>().padding.right + objGrid.GetComponent<GridLayoutGroup>().padding.left)) / contentWidth);
        */
        
        //umsetzten des verhältnisses in höhe
        while (widthRatio > 1.0)
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
