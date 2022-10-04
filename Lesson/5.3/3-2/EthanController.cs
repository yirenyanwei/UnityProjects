using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanController : MonoBehaviour
{
    private Animator ani;
    //动画中的参数转化为id
    private int id_CanMove = Animator.StringToHash("CanMove");

    private int id_MoveTrigger = Animator.StringToHash("MoveTrigger");

    private int id_ShoutSpeed = Animator.StringToHash("ShoutSpeed");

    private int id_Idle_Glance = Animator.StringToHash("Idle_Glance");
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //设置或读取动画参数
        //左箭头
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //用hashId设置效率更高
            ani.SetBool(id_CanMove, true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ani.SetBool(id_CanMove, false);
        }
        //喊叫
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //设置播放速度
            ani.SetFloat(id_ShoutSpeed, 2);
            //1秒内，值差值变为2
            // ani.SetFloat(id_ShoutSpeed, 2, 1, Time.deltaTime);
            ani.SetTrigger(id_MoveTrigger);
        }
        
        //获取当前层动画信息
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        //判断名字-tag
        Debug.Log(info.IsName("Idle_Glance")+"--"+info.IsTag("Idle"));
        //名字hash
        Debug.Log(info.shortNameHash+"--"+id_Idle_Glance);
        
    }
}
