using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour {


    public GameObject sp;
    public GameObject panel1;
    public GameObject panel2;
    // Use this for initialization
    void Start () {
        sp = GameObject.Find("UI Root/Camera/welcome_panel/Sprite");

        //  UIEventListener.Get(sp).onPress = ButtonClick;



        // var canvas = GameObject.Find("UI Root/Camera/welcome_panel");
        //Obtain Panel：Pal_Green
        // panel = canvas.transform.FindChild("UI Root/Camera/login_panel");
        panel1 = GameObject.Find("UI Root/Camera/welcome_panel");
        panel2 = GameObject.Find("UI Root/Camera/login_panel");
        //get by the transform obtain :tansCloseBtn
        // Transform transCloseBtn = canvas.transform.FindChild("Pal_Green/Btn_Close");
        //Obtain 'cpb' Button component

        

    }

    // Update is called once per frame
    void Update () {

        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (panel1 != null || panel2 != null)
            {
                NGUITools.SetActive(panel1, false);
                NGUITools.SetActive(panel2, true);

            }
        }
        

    }
}
