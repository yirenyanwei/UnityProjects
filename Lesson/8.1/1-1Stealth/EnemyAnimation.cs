using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//机器人动画
//速度为导航的期望速度在机器人正前方的投影值
//角速度 为机器人正前方根期望速度的夹角
public class EnemyAnimation : MonoBehaviour
{
    [Header("期望速度和前方夹角忽略度数")]
    public float deadZone = 4f;
    private NavMeshAgent nav;

    private Animator ani;
    private EnemySightingAndHearing enemySightingAndHearing;
    private PlayerHealth playerHealth;
    
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        enemySightingAndHearing = GetComponent<EnemySightingAndHearing>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = PlayerBag.instance.GetComponent<PlayerHealth>();
    }
    //通过动画角色发生位移或旋转时执行
    private void OnAnimatorMove()
    {
        //处理导航和动画都有位移、旋转的问题
        //计算动画的瞬时速度 赋值给导航
        Vector3 velocity = ani.deltaPosition / Time.deltaTime;
        nav.velocity = velocity;
        //旋转使用动画根旋转
        transform.rotation = ani.rootRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // test 导航到玩家
        // nav.SetDestination(PlayerBag.instance.transform.position);
        
        //投影向量  期望速度在机器人正前方的投影向量
        Vector3 projection = Vector3.Project(nav.desiredVelocity, transform.forward);
        //设置速度
        ani.SetFloat(GameConst.SPEED_PARAM, projection.magnitude, 0.2f, Time.deltaTime);
        //角度
        float angle = Vector3.Angle(transform.forward, nav.desiredVelocity);
        if (nav.desiredVelocity == Vector3.zero)
        {
            //到终点角度强行设置为0
            angle = 0;
        }
        //角度很小且能看到玩家时,解决转向速度慢的问题 特殊处理
        if (angle<=deadZone && enemySightingAndHearing.playerInSight)
        {
            angle = 0;
            //直接看向玩家
            transform.LookAt(PlayerBag.instance.transform);
            //修正抖动
            Vector3 eulerAngles = transform.eulerAngles;
            eulerAngles.x = 0;
            eulerAngles.z = 0;
            transform.eulerAngles = eulerAngles;
        }
        //叉乘左手定则求正负
        Vector3 normal = Vector3.Cross(transform.forward, nav.desiredVelocity);
        if (normal.y<0)
        {
            angle = -angle;
        }
        //转换成弧度
        ani.SetFloat(GameConst.ANGULARSPEED_PARAM, Mathf.Deg2Rad*angle, 0.2f, Time.deltaTime);

        if (playerHealth.playerHP>0)
        {
            //设置看到玩家
            ani.SetBool(GameConst.PLAYERINSIGHT_PARAM, enemySightingAndHearing.playerInSight);
        }
        else
        {
            ani.SetBool(GameConst.PLAYERINSIGHT_PARAM,false);
        }
    }
}
