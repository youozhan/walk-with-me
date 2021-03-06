﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintDestroyer : MonoBehaviour {

    // Use this for initialization
    public float destroyTimer;
    public bool destroying = false;
    public float alphaLevelChange=0.05f;
    
    public GameObject plane;
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (destroying)
			return;
		if (transform.position.x!=FootprintsGenerator.leftPos.x&&transform.position.x!=FootprintsGenerator.rightPos.x) {
			destroying = true;
            StartCoroutine(Fade());
        }
		
	}

    IEnumerator Fade()
    {
        float fading = 1f;
        while (fading > 0) { 
            plane.GetComponent<Renderer>().material.color = new Color(1,1,1, fading);
            fading -= alphaLevelChange;
            yield return new WaitForSeconds(.01666f);
        }
        Destroy(gameObject, 0f);
    }
}
