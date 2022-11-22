using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//射击、追捕、巡逻

public class EnemyAI : MonoBehaviour
{
    [Header("机器人到达目标后的等待时间")]
    public float waitTime = 3f;
    [Header("追捕速度")]
    public float chasingSpeed = 5f;
    [Header("巡逻点")]
    public Transform[] wayPoints;
    [Header("巡逻速度")]
    public float patrolingSpeed = 3f;
    //机器人听觉、视觉
    private EnemySightingAndHearing enemySighting;
    //玩家血量
    private PlayerHealth playerHealth;
    //导航
    private NavMeshAgent nav;
    private float timer;
    //巡逻点下标
    private int wayPointIdx = 0;
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        enemySighting = GetComponent<EnemySightingAndHearing>();
        playerHealth = PlayerBag.instance.GetComponent<PlayerHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //射击  看到玩家并且玩家还活着
        if (enemySighting.playerInSight && playerHealth.playerHP>0)
        {
            Shooting();
        }
        //追捕 触发私人警报
        else if (enemySighting.personAlarmPosition!=AlarmSystem.Instance.safePosition)
        {
            Chasing();
        }
        //巡逻
        else
        {
            Patroling();
        }
        
    }

    private void Shooting()
    {
        //停止导航
        nav.isStopped = true;
    }

    private void Chasing()
    {
        //恢复导航
        nav.isStopped = false;
        //设置追捕速度
        nav.speed = chasingSpeed;
        //设置制动距离
        nav.stoppingDistance = 1;
        //导航到警报位置 
        nav.SetDestination(enemySighting.personAlarmPosition);
        //判断有动态路障 才能通过
        if (nav.pathStatus == NavMeshPathStatus.PathPartial)
        {
            //解除警报
            // AlarmSystem.Instance.alarmPosition = AlarmSystem.Instance.safePosition;
            // enemySighting.personAlarmPosition = AlarmSystem.Instance.safePosition;
            // timer = 0;
        }
        //判断到达目标
        if (nav.remainingDistance - nav.stoppingDistance <= 0.05f)
        {
            timer += Time.deltaTime;
            if (timer>=waitTime)
            {
                //解除警报
                AlarmSystem.Instance.alarmPosition = AlarmSystem.Instance.safePosition;
                enemySighting.personAlarmPosition = AlarmSystem.Instance.safePosition;
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }

    private void Patroling()
    {
        //恢复导航
        nav.isStopped = false;
        //设置追捕速度
        nav.speed = patrolingSpeed;
        //设置制动距离
        nav.stoppingDistance = 0;
        //巡逻
        nav.SetDestination(wayPoints[wayPointIdx].position);
        if (nav.remainingDistance-nav.stoppingDistance<=0.05f)
        {
            //计数器
            timer+=Time.deltaTime;
            if (timer>waitTime)
            {
                //下一个点
                wayPointIdx++;
                wayPointIdx %= wayPoints.Length;
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }
}
