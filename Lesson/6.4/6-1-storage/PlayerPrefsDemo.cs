using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("score"));
        Debug.Log(PlayerPrefs.GetString("name"));
    }

    void Save()
    {
        int score = 100;
        string name = "yanwei";
        
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("name", name);
        
        //删除
        PlayerPrefs.DeleteKey("haha");
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
