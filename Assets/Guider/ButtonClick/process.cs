﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class process : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/process"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/data_display"), true);
        Debug.Log("click here!");
    }
}
