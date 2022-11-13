using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [Header("被控制的激光")]
    public GameObject leaser;
    [Header("关闭的声音")]
    public AudioClip switchAud;
    [Header("解锁的材质")]
    public Material unlockMat;
    //屏幕网格渲染器
    private MeshRenderer screenRender;

    private void Awake()
    {
        screenRender = transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(GameConst.PLAYER)&&leaser.activeSelf)
        {
            if (Input.GetButtonDown(GameConst.SWITCH))
            {
                //关闭控制的激光
                leaser.SetActive(false);
                //声音
                AudioSource.PlayClipAtPoint(switchAud, transform.position);
                //更换材质
                screenRender.material = unlockMat;
            }
        }
    }
}
