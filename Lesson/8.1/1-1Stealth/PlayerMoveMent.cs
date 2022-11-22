using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//角色移动及喊叫
public class PlayerMoveMent : MonoBehaviour
{
    [Header("从走路过度到跑步")]
    public float dampTime = 1.5f;
    [Header("转身时间")]
    public float turnSpeed = 10.0f;
    [Header("喊叫声音")]
    public AudioClip shoutClip;
    //虚拟轴
    private float hor, ver;
    //虚拟按键
    private bool sneak, shout;
    private Animator ani;
    private AnimatorStateInfo aniStateInfo;
    private AudioSource aud;
    //方向向量
    private Vector3 dir;
    private Quaternion targetQua;
    //玩家血量
    private PlayerHealth playerHealth;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        dir = Vector3.zero;
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //玩家死亡，收回控制权
        if (playerHealth.playerHP<=0)
        {
            return;
        }
        
        //虚拟按键、虚拟轴
        hor = Input.GetAxis(GameConst.HORIZONTAL);
        ver = Input.GetAxis(GameConst.VERTICAL);
        sneak = Input.GetButton(GameConst.SNEAK);//判断按住
        shout = Input.GetButtonDown(GameConst.SHOUT);//判断按下
        
        //方向
        if (hor != 0 || ver != 0)
        {
            //差值到5.66
            ani.SetFloat(GameConst.SPEED_PARAM, 5.66f, dampTime, Time.deltaTime);
            //方向
            dir.x = hor;
            dir.z = ver;
            //方向向量转为四元数
            targetQua = Quaternion.LookRotation(dir);
            //过度转身
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQua, Time.deltaTime*turnSpeed);
            
        }
        else
        {
            //站立
            ani.SetFloat(GameConst.SPEED_PARAM, 1.5f);
        }
        //潜行
        ani.SetBool(GameConst.SNEAK_PARAM, sneak);
        //喊叫
        if (shout)
        {
            ani.SetTrigger(GameConst.SHOUT_PARAM);
        }
        
        //声音配置
        AudioSetup();
    }

    private void AudioSetup()
    {
        aniStateInfo = ani.GetCurrentAnimatorStateInfo(0);
        if (aniStateInfo.shortNameHash == GameConst.LOCOMOTION_STATE)
        {
            //Locomotion
            if (!aud.isPlaying)
            {
                //脚步声
                aud.Play();
            }
        }
        else
        {
            aud.Stop();
        }
    }
    //喊叫 事件回调
    private void PlayShoutAudio()
    {
        AudioSource.PlayClipAtPoint(shoutClip, transform.position);
    }
}
