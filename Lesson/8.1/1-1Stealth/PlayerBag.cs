using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    //单例脚本
    public static PlayerBag instance;
    //是否拥有钥匙
    public bool hasKey = false;

    private void Awake()
    {
        instance = this;
    }
}
