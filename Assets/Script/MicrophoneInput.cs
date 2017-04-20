using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]		//複数アタッチさせない.

public class MicrophoneInput : MonoBehaviour {

    private new AudioSource audio;

    float loudness;

    public float GetLoudness()
    {
        return loudness;
    }

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
        audio.clip = Microphone.Start(null, true, 10, 44100); 
        audio.loop = true;
        //audio.mute = true;
        while (!(Microphone.GetPosition("") > 0)){ } // Wait until the recording has started
        audio.Play();

    }
	
	// Update is called once per frame
	void Update () {
        loudness = GetAveragedVolume() *10;
        //Debug.Log(loudness);
	}


    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
