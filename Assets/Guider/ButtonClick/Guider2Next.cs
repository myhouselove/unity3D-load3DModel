using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guider2Next : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic2"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic3"), true);
        Debug.Log("click 2 here!");
    }
}
