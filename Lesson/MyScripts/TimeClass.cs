using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //时间缩放
        print(Time.timeScale);
    }

    private void FixedUpdate()
    {
        //固定的时间间隔
        print("fixedDeltaTime:"+Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        //每帧的间隔时间 上一针结束到下一帧开始的时间
        print("delataTime:"+Time.deltaTime);
        
        //从游戏开始到现在的时间间隔
        print("time:"+Time.time);
    }
}
