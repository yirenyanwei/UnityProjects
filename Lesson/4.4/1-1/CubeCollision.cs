using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //当前物体与其它碰撞体产生碰撞，调用一次
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("碰撞开始了+"+other.collider);
        //碰到的物体变色 
        other.collider.GetComponent<MeshRenderer>().material.color = Color.green;
        //碰撞点信息 接触点
        ContactPoint[] points = other.contacts;
        GameObject obj = new GameObject();
        obj.transform.position = points[0].point;
    }
    //碰撞期间每帧调用一次
    private void OnCollisionStay(Collision other)
    {
        Debug.Log("碰撞中+"+other.collider);
    }
    //碰撞离开，调用一次 保持相对运动时才执行。
    private void OnCollisionExit(Collision other)
    {
        Debug.Log("碰撞结束+"+other.collider);
        other.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
