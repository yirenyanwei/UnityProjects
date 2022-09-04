using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //触发开始调用一次
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("开始触发+"+other);
        other.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    //触发过程中每帧调用
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("触发中+"+other);
    }
    //触发结束调用一次
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("触发结束+"+other);
        other.GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
