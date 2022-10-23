using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [Header("怪物血量")]
    public float MonsterHP = 0;
    [Header("怪物高度")]
    public float monsterHeight = 1;
    private NavMeshAgent nav;
    private Animator ani;

    private CapsuleCollider collider;
    //死亡事件
    public Action<Monster> deathEvent;
    //初始化怪物
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void InitMonster(float moveSpeed, float hp, Vector3 des)
    {
        nav.speed = moveSpeed;
        MonsterHP = hp;
        nav.SetDestination(des);
    }

    public void TakeDamage(float damage)
    {
        //扣血
        MonsterHP -= damage;
        if (MonsterHP>0)
        {
            //受伤
            ani.SetTrigger("Damage");
            nav.isStopped = true;
            Invoke("ResumeNavigation", 0.25f);
        }
        else
        {
            //死亡
            ani.SetTrigger("Dead");
            nav.isStopped = true;
            collider.enabled = false;
            //从炮塔移除
            if (deathEvent!=null)
            {
                deathEvent(this);
            }
            Destroy(gameObject, 1.8f);
        }
    }

    private void ResumeNavigation()
    {
        nav.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
