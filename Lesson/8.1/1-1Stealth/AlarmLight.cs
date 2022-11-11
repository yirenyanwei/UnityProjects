using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    [Header("是否开启警报")]
    public bool alarmOn = false;
    [Header("闪烁速度")]
    public float turnSpeed = 3;
    //最高点，最低点 0~4~0
    private float heightIntencity = 4f;
    private float lowIntencity = 0;
    //目标点
    private float targetIntencity;

    private Light lt;

    private void Awake()
    {
        lt = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetIntencity = lowIntencity;
    }

    // Update is called once per frame
    void Update()
    {
        if (alarmOn)
        {
            //切换目标
            if (Mathf.Abs(lt.intensity-targetIntencity)<0.01)
            {
                if (Mathf.Abs(lowIntencity-targetIntencity)<0.01 )
                {
                    targetIntencity = heightIntencity;
                }
                else
                {
                    targetIntencity = lowIntencity;
                }
            }
            //差值光照强度
            lt.intensity = Mathf.Lerp(lt.intensity, targetIntencity, Time.deltaTime * turnSpeed);
            
        }
        else
        {
            lt.intensity = lowIntencity;
        }
    }
}
