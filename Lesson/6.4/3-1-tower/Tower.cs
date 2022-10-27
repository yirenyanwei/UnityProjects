using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("花费金币")]
    public int costMoney = 100;
    [Header("炮塔主体")]
    public Transform turret;
    [Header("旋转速度")]
    public float turnSpeed = 3;
    //炮塔的攻击列表
    private List<Monster> monsters;
    [Header("炮弹预设体")]
    public GameObject bulletPrefab;
    [Header("开炮时间间隔")]
    public float fireInterval = 2;
    [Header("炮弹生成点")]
    public Transform firePoint;
    [Header("炮弹伤害")]
    public float damage = 100;
    private float timer;
    private void Awake()
    {
        monsters = new List<Monster>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monsters.Count<=0)
        {
            return;
        }
        //要攻击的怪物
        Monster monster = monsters[0];
        //转向怪物
        Vector3 dir = monster.GetComponent<Transform>().position+Vector3.up*monster.monsterHeight - turret.position;
        Quaternion qua = Quaternion.LookRotation(dir);
        turret.rotation = Quaternion.Lerp(turret.rotation, qua, Time.deltaTime * turnSpeed);

        timer += Time.deltaTime;
        if (timer >= fireInterval)
        {
            //生成炮弹
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<FireBullet>().InitFireBullet(monster.transform, damage);
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            //加到列表
            Monster monster = other.GetComponent<Monster>();
            monsters.Add(monster);
            //绑定事件
            monster.deathEvent += RemoveMonster;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            monsters.Remove(monster);
            monster.deathEvent -= RemoveMonster;
        }
    }

    public void RemoveMonster(Monster monster)
    {
        //移除怪物
        if (monsters.Contains(monster))
        {
            monsters.Remove(monster);
        }
    }
}
