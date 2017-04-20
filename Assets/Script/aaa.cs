using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour {

    MicrophoneInput mpi;

    // Use this for initialization
    void Start()
    {
        mpi = GameObject.FindObjectOfType<MicrophoneInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float l = mpi.GetLoudness();
        Debug.Log(l);
        if (l > 0.5f)
        {
            transform.localScale = new Vector3(l, l, l);

        }
        else
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
