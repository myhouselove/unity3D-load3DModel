using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Again : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        Debug.Log("click end1");
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/end"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/welcome_panel"), true);

       
        Debug.Log("click end");
    }
}
