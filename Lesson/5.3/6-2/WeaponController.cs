using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("声音片段")]
    public AudioClip audClip;
    private Animator ani;

    private AudioSource aud;
    //武器特效
    private GameObject weaponEffect;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        weaponEffect = transform.Find("WeaponEffect").gameObject;
    }

    private void OnEnable()
    {
        //播放ready的声音
        //播放声音的另一种方法
        AudioSource.PlayClipAtPoint(audClip, transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        //判断正在开火
        bool isFire = ani.GetCurrentAnimatorStateInfo(0).IsName("Fire");
        //正在过渡中 
        if (isFire || ani.IsInTransition(0))
        {
            return;
        }
        //开火
        ani.SetTrigger("Fire");
        
    }
    
    public void PlayFire()
    {
        //更换、播放
        aud.clip = audClip;
        aud.Play();
        //特效
        Invoke("ShowEffect", 0.2f);
        //延时关闭特效
        Invoke("CloseEffect", 0.4f);
    }

    public void Reload()
    {
        //换弹
        ani.SetTrigger("Reload");
        //播放声音的另一种方法
        AudioSource.PlayClipAtPoint(audClip, transform.position);
    }

    private void ShowEffect()
    {
        weaponEffect.SetActive(true);
    }
    private void CloseEffect()
    {
        weaponEffect.SetActive(false);
    }
}
