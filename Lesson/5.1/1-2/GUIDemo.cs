using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDemo : MonoBehaviour
{
    [Header("GUI皮肤")]
    public GUISkin skin;
    private string textFieldText = "this is Text Field";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //每帧执行两次
    private void OnGUI()
    {
        //设置皮肤样式
        GUI.skin = skin;
        
        //手动布局 GUI
        /*
        GUI.Label(new Rect(10,10,100,50), "Hello GUI!");
        bool isClick = GUI.Button(new Rect(10, 60, 100, 50), "GUI Button");
        if (isClick)
        {
            Debug.Log("Click Button");
        }

        textFieldText = GUI.TextField(new Rect(10, 110, 100, 50), textFieldText);
        */
        //自动布局 GUILayout
        GUILayout.Button("this is a button");
        textFieldText = GUILayout.TextField(textFieldText);
    }
}
