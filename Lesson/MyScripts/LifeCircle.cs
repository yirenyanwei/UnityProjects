using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCircle : MonoBehaviour
{
    //唤醒函数 开始时执行一次 脚本不可用时也执行 
    private void Awake()
    {
        print("Awake");
    }
    //脚本组件设置可用时调用
    private void OnEnable()
    {
        print("OnEnable");
    }
    // Start is called before the first frame update
    // 游戏开始后执行一次
    void Start()
    {
        Debug.Log("Start");
    }
    
    //固定时间调用一次，0.02s
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    //每帧执行一次
    void Update()
    {
        
    }
    
    //每帧执行一次
    private void LateUpdate()
    {
        
    }
    //用于渲染旧版UI
    private void OnGUI()
    {
        
    }
    //组件不可用时
    private void OnDisable()
    {
        print("OnDisable");
    }
    //脚本组件销毁的时候
    private void OnDestroy()
    {
        print("OnDestroy");
    }
}
