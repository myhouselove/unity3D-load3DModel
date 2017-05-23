using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;//引入库  
using ZXing.QrCode;
using UnityEngine.UI;
using BestHTTP;
using BestHTTP.Cookies;
using System;
using System.IO;
using LitJson;



public class JsonQRCodeData
{
    public int code;
    public string ticket;
    public string uid;

}


public class Global {
    public static int leng_json;
    public static string token_uid;

}

public class JsonLoginData
{
    public int code;
    public string token;//     #str类型，token，以后的请求都带上
    public string nickname;//  #str类型，昵称
    public int gender;//    #int类型，性别，1是男，2是女
    public string birthday;//  #str类型，出生年月日，格式为2017-01-01
    public string avatar;//    #str类型，用户头像
    public string phone;//     #str类型，手机号码
    public string address;//   #str类型，收货地址
}



public class QRCode : MonoBehaviour {

    public enum JSONTYPE{
        JSON_QRCODE_TYPE=1,
        JSON_LOGIN_TYPE,
        JSON_END,

    };

    public static JsonQRCodeData jsonQRdata;
    public static JsonLoginData jsonLogindata;

    //定义Texture2D对象和用于对应网站的字符串  
    public UITexture UIencode;
    Texture2D encoded;
    public string Lastresult;
    //定义一个UI，来接收图片  
    public RawImage ima;
    bool ok = false;
    public Texture t1;
    // Use this for initialization
    void Start () {
        encoded = new Texture2D(256, 256);
        
        //transform.Find("").GetComponent<UITexture>();
        //t1 = GameObject.Find("UI Root/Camera/login_panel/Window1/Texture");
        OnGetRequest();

        // Lastresult = "http://weixin.qq.com/q/026qJNhdRudl21k0K3Np17";

        Debug.Log("login start!");

    }
    private static Color32[] Encode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }
    // Update is called once per frame
    void Update () {
         var textForEncoding = Lastresult;
        Debug.Log(""+ Lastresult);
         if (textForEncoding != null && ok)
         {
             //二维码写入图片  
             var color32 = Encode(textForEncoding, encoded.width, encoded.height);
             encoded.SetPixels32(color32);
             encoded.Apply();
            //生成的二维码图片附给RawImage  
            // ima.texture = encoded;
            UIencode.mainTexture = encoded;

        }              
    }

    public void OnGetRequest()
    {
        HTTPRequest request = new HTTPRequest(new Uri("https://scanner-test.orbbec.me/user/getqr"), HTTPMethods.Get, OnRequestFinished);
        request.Send();
    }
    public void onGetLoginRequest() {
        HTTPRequest request = new HTTPRequest(new Uri("https://scanner-test.orbbec.me/user/login"+"?uid="+jsonQRdata.uid), HTTPMethods.Get, OnLoginFinished);
        request.Send();
        
    }

    //请求回调   request请求  response响应  这两个参数必须要有 委托类型是OnRequestFinishedDelegate  
    void OnRequestFinished(HTTPRequest request, HTTPResponse response)
    {

       // GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = System.Text.Encoding.Default.GetString(byteArray,33,45);

        ReloadFamilyData(response.DataAsText,1);
        // DisplayFamilyList(m_JsonList);
        if (jsonQRdata.code == 0) {
            // GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "Service error!";
            
             onGetLoginRequest();
        }
       if(jsonQRdata.ticket != null)
        GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = jsonQRdata.ticket;

        Lastresult = jsonQRdata.ticket;// System.Text.Encoding.Default.GetString(byteArray, 33, 45);
        ok = true;
    }
    void OnLoginFinished(HTTPRequest request, HTTPResponse response) {

        ReloadFamilyData(response.DataAsText,2);

        
        if (jsonLogindata.code == 99)
        {
           // GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "code = "+jsonLogindata.code ;
            onGetLoginRequest();
        }
        if (jsonLogindata.code == 0)
        {
            Global.token_uid = jsonLogindata.token;

            Debug.Log("1.birthday:" + jsonLogindata.birthday +
            "2.address:" + jsonLogindata.address+"3.token:"+jsonLogindata.token+"4.nickname:"+jsonLogindata.nickname+"5.gender:"+jsonLogindata.gender+
            "6.avater:"+jsonLogindata.avatar+"7.phone:"+jsonLogindata.phone);
            GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "code = " + jsonLogindata.code;
            GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "all code = " + response.DataAsText;
            // displayUserData();

            WriteNewFile("Assets/Guider/UserData/json.txt", response.DataAsText);

            NGUITools.SetActive(GameObject.Find("UI Root/Camera/login_panel"), false);
            NGUITools.SetActive(GameObject.Find("UI Root/Camera/display_panel"), true);
        }

    }
 public static void WriteNewFile(string FileName, string Message)
{
    if (File.Exists(FileName))
    {
        File.Delete(FileName);
    }
    using (FileStream fileStream = File.Create(FileName))
    {
        byte[] bytes = System.Text.Encoding.Default.GetBytes(Message);
            Debug.Log("HEREE");
        fileStream.Write(bytes, 0, bytes.Length);
            Global.leng_json = bytes.Length;
            Debug.Log("HEREE + ="+Global.leng_json);
        }
}

/* private void displayUserData()
 {

     GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "bir:"+jsonLogindata.birthday+
         "address"+jsonLogindata.address;


     throw new NotImplementedException();
 }*/

public static void ReloadFamilyData(string tmp,int type)
    {
        switch (type) {
            case 1:
                jsonQRdata = JsonMapper.ToObject<JsonQRCodeData>(tmp);
                break;
            case 2:
                jsonLogindata = JsonMapper.ToObject<JsonLoginData>(tmp);
                GameObject.Find("UI Root/Camera/login_panel/Window1/Label").GetComponent<UILabel>().text = "code = " + jsonLogindata.code;
                break;
            default:
                break;


        } 
       
    }

}
