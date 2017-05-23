using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using LitJson;
using System.Net;
using System.Net.Sockets;



public class UserDataProcess : MonoBehaviour {


    public UILabel nickname;
    public UILabel Gender;
    public UILabel Birthday;
    public UILabel Phone;
    public string PicUrl;
    public UISprite pic;
    public UITexture UIencode;

    public string jsondata;
    public JsonLoginData jsonUserdata;

    private char[] charData;//= new char[1000];
    private byte[] byData;//= new byte[100];

    // Use this for initialization
    void Start () {
        Debug.Log("UserDataProcess + =" + Global.leng_json);

        byData = new byte[Global.leng_json];
        Read();
        processData();
       // showData();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Read()
    {
        try
        {
            FileStream file = new FileStream("Assets/Guider/UserData/json.txt", FileMode.Open);
            file.Seek(0, SeekOrigin.Begin);
            file.Read(byData, 0, Global.leng_json); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
            jsondata = System.Text.Encoding.Default.GetString(byData);
            Debug.Log(jsondata);
            jsonUserdata = JsonMapper.ToObject<JsonLoginData>(System.Text.Encoding.UTF8.GetString(byData));           
            file.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void processData()
    {
        if (jsonUserdata == null)
        {
            return;
        }
        nickname.text = jsonUserdata.nickname;
        Phone.text = jsonUserdata.phone;
        Birthday.text = jsonUserdata.birthday;
        Gender.text = jsonUserdata.gender.ToString();
        PicUrl = jsonUserdata.avatar;


        
        string filepath = "Assets/Guider/UserData/pic.jpg";
        WebClient mywebclient = new WebClient();
        mywebclient.DownloadFile(PicUrl, filepath);


        LoadByIO();




    }

    private void LoadByIO()
    {
        double startTime = (double)Time.time;
        //创建文件读取流
        FileStream fileStream = new FileStream("Assets/Guider/UserData/pic.jpg", FileMode.Open, FileAccess.Read);
        fileStream.Seek(0, SeekOrigin.Begin);
        //创建文件长度缓冲区
        byte[] bytes = new byte[fileStream.Length];
        //读取文件
        fileStream.Read(bytes, 0, (int)fileStream.Length);

        //释放文件读取流
        fileStream.Close();
        fileStream.Dispose();
        fileStream = null;

        //创建Texture
        int width = 300;
        int height = 372;
        Texture2D texture = new Texture2D(width, height);
        texture.LoadImage(bytes);

        UIencode.mainTexture = texture;

        //创建Sprite
        //  Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        // image.sprite = sprite;

        startTime = (double)Time.time - startTime;
        Debug.Log("IO加载用时:" + startTime);
    }
}
