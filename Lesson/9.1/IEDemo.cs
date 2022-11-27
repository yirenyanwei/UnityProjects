using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEDemo : MonoBehaviour
{
    private Coroutine coroutine;
    //启动协程
    private void Start()
    {
        //调用协程
        // StartCoroutine(Demo());
        // StartCoroutine(Circle());

        // StartCoroutine(InitMonsters(2, 1));

        // coroutine = StartCoroutine(WaitForCoroutine());
        // StartCoroutine(PrintNum());

        //字符串方式调用
        // StartCoroutine("WaitForCoroutine");

        //停止协程
        // StopCoroutine(coroutine);
        //停止所有协程
        // StopAllCoroutines();
        
        //原理
        IEnumerator it = PrintNum();
        //执行PrintNum直到遇到yield
        while (it.MoveNext())
        {
            
        }

    }
    //1、定义协同程序
    IEnumerator Demo()
    {
        Debug.Log("111");
        //协程暂停，等一帧恢复
        yield return null;
        Debug.Log("222");
    }

    IEnumerator Circle()
    {
        while (true)
        {
            //每帧执行一次，实现update
            Debug.Log("circle");
            yield return null;
        }
    }
    //2、间隔几秒后执行
    IEnumerator MyWaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("生成野怪");
    }

    IEnumerator InitMonsters(float waveInterval, float monsterInterval)
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(waveInterval);
            for (int j = 0; j < 3; j++)
            {
                Debug.Log("Create monster:"+i+"-"+j);
                yield return new WaitForSeconds(monsterInterval);
                
            }
        }
    }
    
    //3、一帧结束后执行 OnGUI之后执行
    IEnumerator MyWaitForEndOfFrame()
    {
        Debug.Log("111");
        yield return new WaitForEndOfFrame();
        Debug.Log("222");
    }
    
    //4、new WaitForFixedUpdate()   等0.02秒执行
    
    //5、等子协程执行完再执行
    IEnumerator WaitForCoroutine()
    {
        Debug.Log("start1");
        yield return StartCoroutine(MyWaitForEndOfFrame());
        Debug.Log("end1");
        
    }
    //6、跳出协程
    IEnumerator PrintNum()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
            if (i == 5)
            {
                yield break;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
    
    private void Update()
    {
        // Debug.Log("Update");
    }
}
