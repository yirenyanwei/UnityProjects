using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//机器人视觉和听觉、位置和消息的接收
//听觉只会出发个人警报，单个机器人去固定位置查看
//看到了触发全局警报
public class EnemySightingAndHearing : MonoBehaviour
{
    [Header("机器人视野角度")]
    public float fieldOfView = 110;
    [HideInInspector]
    public bool playerInSight = false;//玩家是否在视野范围内
    //私人警报位置
    public Vector3 personAlarmPosition;
    //上一帧的全局警报位置
    private Vector3 previousAlarmPosition;
    //机器人指向玩家的方向向量
    private Vector3 dir;
    //玩家
    private Transform player;

    private PlayerHealth playerHealth;
    //玩家动画
    private Animator playerAni;
    //射线
    private RaycastHit hit;
    //导航组件
    private NavMeshAgent nav;
    //路径对象
    private NavMeshPath path;
    //触发器
    private SphereCollider sphereCollider;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        sphereCollider = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        previousAlarmPosition = AlarmSystem.Instance.safePosition;
        personAlarmPosition = AlarmSystem.Instance.safePosition;
        player = PlayerBag.instance.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerAni = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAlarmPosChanged();
    }
    //检测警报位置变化
    void CheckAlarmPosChanged()
    {
        //当全局警报位置发生变化的时候，将全局警报位置赋值给机器人
        if (previousAlarmPosition!=AlarmSystem.Instance.alarmPosition)
        {
            personAlarmPosition = AlarmSystem.Instance.alarmPosition;
        }
        previousAlarmPosition = AlarmSystem.Instance.alarmPosition;
    }
    //视觉  1、角度 2、距离 3、障碍物 
    void Sighting()
    {
        playerInSight = false;
        dir = player.position - transform.position;
        //机器人到玩家的向量与机器人正前方的夹角
        float angle = Vector3.Angle(dir, transform.forward);
        if (angle>fieldOfView/2)
        {
            return;
        }
        //检测障碍物 判断眼睛的位置
        if (Physics.Raycast(transform.position+Vector3.up*GameConst.PLAYER_EYES_OFFSET, 
                dir, out hit))
        {
            //检测到玩家  也会检测到自己，把自己的collier调小点
            if (hit.collider.CompareTag(GameConst.PLAYER))
            {
                playerInSight = true;
                //触发警报
                AlarmSystem.Instance.alarmPosition = player.position;
            }
        }
    }
    //听觉  判断玩家动画状态、导航距离
    void Hearing()
    {
        AnimatorStateInfo info0 = playerAni.GetCurrentAnimatorStateInfo(0);
        bool isLocomotion = info0.shortNameHash==GameConst.LOCOMOTION_STATE;
        AnimatorStateInfo info1 = playerAni.GetCurrentAnimatorStateInfo(1);
        bool isShout = info1.shortNameHash == GameConst.SHOUT_PARAM;

        if (!isLocomotion && !isShout)
        {
            return;
        }
        //导航方式找玩家
        bool canArrive = nav.CalculatePath(player.position, path);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            //有动态路障到不了
            // return;
        }
        if (!canArrive)
        {
            return;
        }
        //计算距离
        float distance = 0;
        Vector3[] corners = path.corners;
        if (corners.Length>0)
        {
            distance += Vector3.Distance(transform.position, corners[0]);
            for (int i = 1; i < corners.Length; i++)
            {
                distance+=Vector3.Distance(corners[i], corners[i-1]);
            }
            distance += Vector3.Distance(corners[corners.Length-1], player.position);
        }

        if (distance<=sphereCollider.radius)
        {
            //在设定距离内
            //触发个人警报
            personAlarmPosition = player.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //玩家死亡不检测
        if (playerHealth.playerHP<=0)
        {
            return;
        }
        if (other.CompareTag(GameConst.PLAYER))
        {
            //当玩家进入触发器才判断
            Sighting();
            Hearing();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER))
        {
            //玩家离开了
            playerInSight = false;
        }
    }
}
