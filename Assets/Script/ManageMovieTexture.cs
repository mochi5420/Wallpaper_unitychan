using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMovieTexture : MonoBehaviour {


    public MovieTexture movie;

	// Use this for initialization
	void Start () {

        movie.Play();
        movie.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
