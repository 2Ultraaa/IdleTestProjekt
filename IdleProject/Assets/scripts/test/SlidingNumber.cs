using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidingNumber : MonoBehaviour {

    public Text text;
    public float animTime;

    float desiredNumb;
    float initialNumb;
    float currentNumb;

    public void SetNumber(float value) {
        initialNumb = currentNumb;
        desiredNumb = value;
        StartCoroutine(Slide(animTime));
    }

    public void AddToNumber(float value) {
        initialNumb = currentNumb;
        desiredNumb += value;
        StartCoroutine(Slide(animTime));
    }

    /*private void Update() {
        if(currentNumb != desiredNumb)
        {
            if (initialNumb < desiredNumb)
            {
                currentNumb += (animTime * Time.deltaTime) * (desiredNumb - initialNumb);
                if (currentNumb >= desiredNumb)
                {
                    currentNumb = desiredNumb;
                }
            }
            else
            {
                currentNumb -= (animTime * Time.deltaTime) * (initialNumb - desiredNumb);
                if (currentNumb <= desiredNumb)
                {
                    currentNumb = desiredNumb;
                }
            }

            text.text = currentNumb.ToString("0");
            
        }
    }*/

    IEnumerator Slide(float time) {
        if (currentNumb != desiredNumb)
        {
            if (initialNumb < desiredNumb)
            {
                float t = 0f;
                while (t <= 1f)
                {
                    t += Time.deltaTime / time;
                    currentNumb = initialNumb + (desiredNumb - initialNumb) * t;
                    if (currentNumb >= desiredNumb)
                    {
                        currentNumb = desiredNumb;
                    }
                    text.text = (currentNumb).ToString("0");
                    yield return null;
                }                
            }
            else
            {
                float t = 0f;
                while (t <= 1f)
                {
                    t += Time.deltaTime / time;
                    currentNumb = initialNumb - (initialNumb - desiredNumb) * t;
                    if (currentNumb <= desiredNumb)
                    {
                        currentNumb = desiredNumb;
                    }
                    text.text = (currentNumb).ToString("0");
                    yield return null;
                }     
            }
        }
    }
}
