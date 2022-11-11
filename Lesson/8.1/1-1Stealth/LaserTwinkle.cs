using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//激光闪烁
public class LaserTwinkle : MonoBehaviour
{
    [Header("闪烁间隔")]
    public float interval = 1;

    private float timer = 0;
    //原始坐标
    private Vector3 originPosition;
    //不可见坐标
    private Vector3 distancePosition;
    //是否显示
    private bool isShow = true;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        distancePosition = Vector3.up*1000;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=interval)
        {
            isShow = !isShow;
            timer = 0;
        }

        if (isShow)
        {
            transform.position = originPosition;
        }
        else
        {
            transform.position = distancePosition;
        }
    }
}
