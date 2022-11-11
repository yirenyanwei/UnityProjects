using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//警报触发器
public class AlarmTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER))
        {
            //触发警报
            AlarmSystem.Instance.alarmPosition = other.transform.position;
        }
    }
}
