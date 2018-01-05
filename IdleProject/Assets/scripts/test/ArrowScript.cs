using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public int waitingTime;
    
    void Start() {
        this.GetComponent<Animator>().SetTrigger("Start");
        StartCoroutine(Wait());

    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(waitingTime);
        this.GetComponent<Animator>().SetTrigger("End");
    }
}
