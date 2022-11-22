using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敌人设计
public class EnemyShoot : MonoBehaviour
{
    [Header("是否显示IK动画")]
    public bool isIK = false;

    private Animator ani;
    private Transform player;
    private PlayerHealth playerHealth;
    private ShootingEffect shootingEffect;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        shootingEffect = GetComponentInChildren<ShootingEffect>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBag.instance.transform;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(1);
        if (info.shortNameHash != GameConst.WEAPONSHOOT_STATE && info.shortNameHash != GameConst.WEAPONRAISE_STATE)
        {
            return;
        }
        //设置右手、眼睛权重
        ani.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        ani.SetLookAtWeight(1);
        //设置位置
        ani.SetIKPosition(AvatarIKGoal.RightHand, player.position+Vector3.up*GameConst.PLAYER_HURT_OFFSET);
        ani.SetLookAtPosition(player.position+Vector3.up*GameConst.PLAYER_HURT_OFFSET);
        
    }
    //射击的帧事件
    public void OnEventShoot()
    {
        //播放射击特效
        shootingEffect.PlayShootingEffect();
        //掉血
        playerHealth.TakeDamage(50);
    }
}
