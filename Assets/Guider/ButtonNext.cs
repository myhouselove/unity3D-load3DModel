using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNext : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/display_panel"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic"), true);
        Debug.Log("click here!");
    }
}
