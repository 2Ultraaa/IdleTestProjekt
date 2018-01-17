using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour  {

    public AudioClip soundDown;
    public AudioClip soundUp;
    [RangeAttribute(0f, 1f)]
    public float volume;
    //der button-up ton wird erst gespielt, wenn man den button länger als 1/4 s gedrückt hatte
    //noch nicht optimal, bei langer runtime wird berechnung groß
    float inhib;

    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void Start ()      {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = volume;
        source.playOnAwake = false;
    }

    public void PlaySoundDown ()     {
        source.clip = soundDown;
        source.PlayOneShot(soundDown);
        //aktuelle runtime zwischenspeichern
        inhib = Time.time;
    }

    public void PlaySoundUp () {
        //neue aktuelle runtime - inhib
        if (Time.time - inhib > .25)
        {
            source.clip = soundUp;
            source.PlayOneShot(soundUp);
        }
    }
}﻿