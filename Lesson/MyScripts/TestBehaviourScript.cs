using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using NamespaceTest.NamespaceTest1;

public class TestBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // TestBase baseObj = new TestBase();
        
        /*
        TestClass classObj = new TestClass();
        TestClass.num++;
        Debug.Log(TestClass.GetNum());
        
        RectangleT tObj = new RectangleT();
        tObj.setWidth(100);
        tObj.setHeight(100);
        tObj.getArea();
        tObj.getCost(2);
        */

        NamespaceTest.TestNameSpace nObj = new NamespaceTest.TestNameSpace();
        TestNameSpace1 nObj1 = new TestNameSpace1();
        
        //try catch
        try
        {
            //读写文件
            StreamReader f = new StreamReader("Assets/Scripts/a.json");
            string line;
            while ((line = f.ReadLine())!=null) 
            {
                Debug.Log(line);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        //Attribute
        TestAttribute attr = new TestAttribute();
        attr.GetValue();
        
        //反射
        Type tpe = typeof(TestAttribute);
        object[] attributes = tpe.GetCustomAttributes(true);
        for (int i = 0; i < attributes.Length; i++)
        {
            Debug.Log((attributes[i]));
            DebugInfo dbi = (DebugInfo) attributes[i];
            if (dbi != null)
            {
                dbi.Display();
            }
        }
        //反射方法的特性
        foreach (MethodInfo m in tpe.GetMethods())
        {
            foreach (Attribute a in m.GetCustomAttributes(true))
            {
                DebugInfo dbi = (DebugInfo) a;
                if (dbi != null)
                {
                    dbi.Display();
                }
            }
        }
        
        //索引器
        TestIndexer indexer = new TestIndexer();
        indexer[0] = "hello";
        Debug.Log(String.Format("{0}-{1}", indexer[0], indexer[9]));

        
        //代理
        NumberChanger nc1 = new NumberChanger(TestDelegate.AddNum);
        //匿名方法
        NumberChanger nc2 = delegate(int i)
        {
            return 2;
        };
        nc1(10);
        Debug.Log(TestDelegate.getNum());
        
        //声明事件
        TestEvent evt = new TestEvent("update");
        TestSubscribe sub = new TestSubscribe();
        evt.subscribe(new TestEvent.MyDelegate(sub.onUpdate));
        evt.publisher();
        
        //Collection
        ArrayList al = new ArrayList();
        al.Add(10);
        al.Add("hello");
        int alValue = (int)al[0];
        Debug.Log(alValue);
        
        //Thread
        TestThread.Start();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
