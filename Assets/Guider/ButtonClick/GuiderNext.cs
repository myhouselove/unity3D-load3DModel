﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiderNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic2"), true);
        Debug.Log("click here!");
    }
}
