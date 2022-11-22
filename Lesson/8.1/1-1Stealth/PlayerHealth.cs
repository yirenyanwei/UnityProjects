using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//玩家的血量
public class PlayerHealth : MonoBehaviour
{
    [Header("玩家血量")]
    public int playerHP = 100;
    [Header("结束游戏声音")]
    public AudioClip endClip;

    private Animator ani;

    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //计算伤害
    public void TakeDamage(int damage)
    {
        if (playerHP<=0)
        {
            //防止重复执行
            return;
        }
        playerHP -= damage;
        //判断死亡
        if (playerHP<=0)
        {
            playerHP = 0;
            //播放动画、声音
            ani.SetTrigger(GameConst.DEAD_PARAM);
            AudioSource.PlayClipAtPoint(endClip, transform.position);
            //解除警报
            AlarmSystem.Instance.alarmPosition = AlarmSystem.Instance.safePosition;
            //取消玩家标签
            tag = "Untagged";
            
            
            Invoke("RestartGame", 4.4f);
        }
    }
    //重新开始游戏
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
