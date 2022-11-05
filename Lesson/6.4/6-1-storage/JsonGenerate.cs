using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Json;

public class JsonGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JsonObject jObj = new JsonObject();
        //普通类型
        jObj.Add("name", "xiaoming");
        //添加数组类型
        JsonArray score = new JsonArray();
        score.AddRange(20,30,40);//添加多个
        jObj.Add("score", score);
        //对象类型
        JsonObject hobby = new JsonObject();
        hobby.Add("favorite", "football");
        jObj.Add("hobby", hobby);
        
        Debug.Log(jObj.ToString());
        
        
        //读取  报错。。。
        string jsStr = "{'name':'xiaoming'}";
        // JsonValue jvalue = JsonValue.Parse(jsStr);
        // Debug.Log("json解析:"+jvalue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
