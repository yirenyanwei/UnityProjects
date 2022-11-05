using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class JsonHobby
{
    public string favorite;
}
public class JsonStudent
{
    public string name;
    public int[] score;
    public JsonHobby hobby;

}
public class JsonParse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string jsonStr = "{\"name\":\"xiaoming\",\"score\":[20,30,40],\"hobby\":{\"favorite\":\"football\"}}";
        //第一种解析
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        Debug.Log(jsonData["name"]);
        for (int i = 0; i < jsonData["score"].Count; i++)
        {
            Debug.Log("Score:"+jsonData["score"][i]);
        }
        //模板解析
        JsonStudent stu = JsonMapper.ToObject<JsonStudent>(jsonStr);
        Debug.Log("JsonStudent:"+stu.score[0]+":"+stu.hobby.favorite);
        
        //转为字符串
        Debug.Log("转为字符串:"+JsonMapper.ToJson(stu));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
