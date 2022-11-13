using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//控制电梯
public class LiftController : MonoBehaviour
{
    [Header("电梯速度")]
    public float moveSpeed = 3f;
    //是否移动
    public bool isMove = false;
    private AudioSource audioSource;
    private float timer = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BeginMove()
    {
        isMove = true;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    private void Update()
    {
        if (!isMove)
        {
            return;
        }

        timer += Time.deltaTime;
        //电梯上升
        transform.position += Time.deltaTime * moveSpeed * Vector3.up;
        //玩家上升
        PlayerBag.instance.transform.position += Time.deltaTime * moveSpeed * Vector3.up;
        if (timer>=audioSource.clip.length)
        {
            //移动时间为音效时间
            isMove = false;
            
            //结束游戏 加载下一关
            SceneManager.LoadScene(0);
        }
    }
}
