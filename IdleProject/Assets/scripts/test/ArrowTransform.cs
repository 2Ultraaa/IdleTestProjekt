using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTransform : MonoBehaviour {

    /*
    public GameObject arrowObj;
    public GameObject nextToObj;

    [RangeAttribute (1, 4)]
    public int myCase;

    RectTransform arrowRect;
    RectTransform nextToRect;
    Vector2 nextToSize;    

	void Start () {
        arrowRect = arrowObj.GetComponent<RectTransform>();
        nextToRect = nextToObj.GetComponent<RectTransform>();
        nextToSize = nextToRect.rect.size;

        //1: pfeil von oben, 2: pfeil von rechts, 3: pfeil von unten, 4: pfeil von links
        //wichtig: im script angeben, neben welchem objekt der pfeil sein soll!
        switch (myCase)
        {
            //pfeil zeigt nach unten
            case 1:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -270);

                if (nextToSize[0] < arrowRect.rect.width)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[0], nextToSize[0]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x, nextToRect.transform.localPosition.y + (nextToRect.rect.height / 2 + arrowRect.sizeDelta[1] / 2), 0);
                break;

            //pfeil zeigt nach links
            case 2:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);

                if (nextToSize[1] < arrowRect.rect.height)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[1], nextToSize[1]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x + (nextToRect.rect.width / 2 + arrowRect.sizeDelta[0] / 2), nextToRect.transform.localPosition.y, 0);
                break;

            //pfeil zeigt nach oben 
            case 3:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -90);

                if (nextToSize[0] < arrowRect.rect.width)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[0], nextToSize[0]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x, nextToRect.transform.localPosition.y + (-1 * nextToRect.rect.height / 2 - arrowRect.sizeDelta[1] / 2), 0);
                break;

            //pfeil zeigt nach rechts
            case 4:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -180);

                if (nextToSize[1] < arrowRect.rect.height)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[1], nextToSize[1]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x + (-1 * nextToRect.rect.width / 2 - arrowRect.sizeDelta[0] / 2), nextToRect.transform.localPosition.y, 0);
                break;

            //default
            default:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
	}	*/
    public GameObject arrowObj;
    RectTransform arrowRect;
    RectTransform nextToRect;
    Vector2 nextToSize;

    public void myStuff(GameObject nextToObj, int myCase) {
        arrowRect = arrowObj.GetComponent<RectTransform>();
        nextToRect = nextToObj.GetComponent<RectTransform>();
        nextToSize = nextToRect.rect.size;

        //1: pfeil von oben, 2: pfeil von rechts, 3: pfeil von unten, 4: pfeil von links
        switch (myCase)
        {
            //pfeil zeigt nach unten
            case 1:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -270);

                if (nextToSize[0] < arrowRect.rect.width)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[0], nextToSize[0]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x, nextToRect.transform.localPosition.y + (nextToRect.rect.height / 2 + arrowRect.sizeDelta[1] / 2), 0);
                break;

            //pfeil zeigt nach links
            case 2:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);

                if (nextToSize[1] < arrowRect.rect.height)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[1], nextToSize[1]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x + (nextToRect.rect.width / 2 + arrowRect.sizeDelta[0] / 2), nextToRect.transform.localPosition.y, 0);
                break;

            //pfeil zeigt nach oben 
            case 3:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -90);

                if (nextToSize[0] < arrowRect.rect.width)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[0], nextToSize[0]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x, nextToRect.transform.localPosition.y + (-1 * nextToRect.rect.height / 2 - arrowRect.sizeDelta[1] / 2), 0);
                break;

            //pfeil zeigt nach rechts
            case 4:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, -180);

                if (nextToSize[1] < arrowRect.rect.height)
                {
                    arrowRect.sizeDelta = new Vector2(nextToSize[1], nextToSize[1]);
                }

                arrowRect.transform.localPosition = new Vector3(nextToRect.transform.localPosition.x + (-1 * nextToRect.rect.width / 2 - arrowRect.sizeDelta[0] / 2), nextToRect.transform.localPosition.y, 0);
                break;

            //default
            default:
                arrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }
}
