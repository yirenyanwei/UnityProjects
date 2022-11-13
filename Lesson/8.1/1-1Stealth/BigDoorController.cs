using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDoorController : MonoBehaviour
{
    [Header("门声音")]
    public AudioClip doorClip;
    [Header("拒绝的声音")]
    public AudioClip denyClip;
    [Header("内门的动画")]
    public Animator innerDoorAni;
    [Header("电梯控制器")]
    public LiftController liftController;
    private Animator ani;
    private Vector3 dir;//门指向玩家向量
    private SphereCollider sphereCollider;//门触发器

    private void Awake()
    {
        ani = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER))
        {
            if (PlayerBag.instance.hasKey)
            {
                //开门
                ani.SetBool(GameConst.DOOROPEN_PARAM, true);
                innerDoorAni.SetBool(GameConst.DOOROPEN_PARAM, true);
                //声音
                AudioSource.PlayClipAtPoint(doorClip, transform.position);
            }
            else
            {
                //播放拒绝开门
                AudioSource.PlayClipAtPoint(denyClip, transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER))
        {
            if (PlayerBag.instance.hasKey)
            {
                //关门
                ani.SetBool(GameConst.DOOROPEN_PARAM, false);
                innerDoorAni.SetBool(GameConst.DOOROPEN_PARAM, false);
                //声音
                AudioSource.PlayClipAtPoint(doorClip, transform.position);
                
                //防止门再次打开  判断从里边离开触发器
                dir = other.transform.position - transform.position;
                if (dir.z>0)
                {
                    sphereCollider.enabled = false;
                    //电梯上升
                    liftController.BeginMove();
                }
            }
            
        }
    }
}
