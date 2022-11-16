using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LitterDoorController : MonoBehaviour
{
    public AudioClip doorAudio;
    //人数计数器
    private int counter = 0;
    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            //解决机器人碰撞体太大的bug
            return;
        }
        if (other.CompareTag(GameConst.PLAYER) || other.CompareTag(GameConst.ENEMY))
        {
            counter++;
            if (counter>0)
            {
                //开门
                ani.SetBool(GameConst.DOOROPEN_PARAM, true);
                AudioSource.PlayClipAtPoint(doorAudio, transform.position);
            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.isTrigger)
        {
            //解决机器人碰撞体太大的bug
            return;
        }
        if (other.CompareTag(GameConst.PLAYER) || other.CompareTag(GameConst.ENEMY))
        {
            counter--;
            if (counter<=0)
            {
                //关门
                ani.SetBool(GameConst.DOOROPEN_PARAM, false);
                AudioSource.PlayClipAtPoint(doorAudio, transform.position);
            }
        }

        
    }
}
