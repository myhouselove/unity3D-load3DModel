using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guider3Next : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic3"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/process"), true);
        Debug.Log("click  3 here!");
    }
}
