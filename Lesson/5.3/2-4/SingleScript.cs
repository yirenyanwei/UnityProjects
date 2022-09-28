using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleScript : MonoBehaviour
{
    public SingleScript Instance;
    private void Awake()
    {
        Instance = this;
        //阻止切换场景时销毁对象 会显示到另一个场景上
        DontDestroyOnLoad(gameObject);
    }
}
