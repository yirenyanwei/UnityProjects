using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEffect : MonoBehaviour
{
    [Header("射击特效")]
    public AudioClip shootingAud;

    private LineRenderer lineRenderer;

    private Light light;

    private Transform player;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        light = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerBag.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //播放射击特效
    public void PlayShootingEffect()
    {
        //设置激光  起点枪口处，终点玩家身体
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, player.position+Vector3.up*GameConst.PLAYER_HURT_OFFSET);
        //设置灯光
        light.enabled = true;
        //设置音效
        AudioSource.PlayClipAtPoint(shootingAud, transform.position);
        
        Invoke("DelayClose", 0.1f);
    }

    private void DelayClose()
    {
        lineRenderer.positionCount = 0;
        light.enabled = false;
    }
}
