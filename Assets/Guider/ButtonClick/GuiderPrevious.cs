using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiderPrevious : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        NGUITools.SetActive(GameObject.Find("UI Root/Camera/GuiderPic"), false);
        NGUITools.SetActive(GameObject.Find("UI Root/Camera/display_panel"), true);
        
        Debug.Log("click here111!");
    }
}
