using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //追踪目标
    private Transform target;
    [Header("追踪速度")]
    public float speed;
    //炮弹伤害
    [HideInInspector]
    public float damage = 100;

    public void InitFireBullet(Transform tar, float damage)
    {
        target = tar;
        this.damage = damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //追踪目标
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
