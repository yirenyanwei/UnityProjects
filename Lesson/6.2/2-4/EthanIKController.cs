using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanIKController : MonoBehaviour
{
    [Header("IK 动画开关")]
    public bool IKActive = false;
    [Header("IK 指向的目标")]
    public Transform target;
    [Header("目标身高")]
    public float trargetHeight = 1.8f;

    public float fireMaxAngle = 100;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //IK动画回调，每帧执行一次
    private void OnAnimatorIK(int layerIndex)
    {
        //玩家指向敌人的向量
        Vector3 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, transform.forward);
        if (angle<=fireMaxAngle/2)
        {
            IKActive = true;
        }
        else
        {
            IKActive = false;
        }
        
        if (!IKActive)
        {
            ani.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            ani.SetLookAtWeight(0);
            return;
        }
        // 设置IK权重
        ani.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        //设置IK的位置 打目标的头部
        ani.SetIKPosition(AvatarIKGoal.RightHand, target.position+Vector3.up*trargetHeight);
        
        //设置眼睛IK权重
        ani.SetLookAtWeight(1);
        ani.SetLookAtPosition(target.position+Vector3.up*trargetHeight);
    }
}
