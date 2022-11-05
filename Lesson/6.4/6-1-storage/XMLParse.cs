using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLParse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        XmlDocument doc = new XmlDocument();
        //加载xml
        doc.Load(Application.dataPath+"/UnityProjects/Lesson/6.4/6-1-storage/person.xml");
        //获取根节点
        XmlElement root = doc.DocumentElement;
        //获取单个node
        XmlNode nameNode = root.SelectSingleNode("person/name");
        Debug.Log(nameNode.InnerText);
        //获取多个
        XmlNodeList nameNodes = root.SelectNodes("person/name");
        foreach (XmlNode item in nameNodes)
        {
            Debug.Log("ITEM:"+item.InnerText);
        }
        
        //解析
        XmlNodeList persons = root.ChildNodes;
        for (int i = 0; i < persons.Count; i++)
        {
            XmlNode person = persons[i];
            Debug.Log(person.Name);
            for (int j = 0; j < person.ChildNodes.Count; j++)
            {
                XmlNode attr = person.ChildNodes[j];
                Debug.Log(attr.Name+":"+attr.InnerText);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
