using System;
using UnityEngine;

// 一个自定义特性 BugFix 被赋给类及其成员
[AttributeUsage(AttributeTargets.All,
    AllowMultiple = true)]
public class DebugInfo: Attribute
{
    private int id;
    public string message;

    public DebugInfo(int _id)
    {
        id = _id;
        Debug.Log(String.Format("id={0}", _id));
    }

    public void Display()
    {
        Debug.Log(String.Format("Display={0}", id));
    }
    
    public int ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public string Message
    {
        get
        {
            return message;
        }
        set
        {
            message = value;
        }
    }
}

[DebugInfo(1, Message = "this is Class")]
public class TestAttribute
{
    [DebugInfo(2, Message = "this is Function")]
    public void GetValue()
    {
        Debug.Log("TestAttribute--");
    }
}