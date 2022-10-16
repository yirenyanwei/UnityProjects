using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimationController : MonoBehaviour
{
    [Header("过渡时间")]
    [Range(0, 3)]
    public float SmoothTime = 3f;
    [Header("移动速度")]
    public float Speed = 3f;
    [Header("转身速度")]
    public float TurnSpeed = 10.0f;

    public AudioClip shoutClip;

    private Animator ani;
    private AudioSource aud;
    private float hor, ver;

    private bool sneak = false;

    private bool shout;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        sneak = Input.GetButton("Sneak");//获取虚拟按键 静步
        shout = Input.GetButtonDown("Shout");//喊叫
        //设置潜行
        ani.SetBool("Sneak", sneak);
        if (shout)
        {
            ani.SetTrigger("Shout");
            
        }
        //按下方向键
        if (hor != 0 || ver != 0)
        {
            //平滑设置值  配合融合树可以实现从idle->walk->run
            ani.SetFloat("Speed", 5.6f, SmoothTime, Time.deltaTime);
            
            //将向量转化为四元数
            Quaternion targetQuaternion = Quaternion.LookRotation(new Vector3(hor, 0, ver));
            //转向
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, TurnSpeed * Time.deltaTime);
        }
        else
        {
            //立刻停止
            ani.SetFloat("Speed", 0f);
        }
        //判断状态
        bool isMove = ani.GetCurrentAnimatorStateInfo(0).IsName("Move");
        if (isMove)
        {
            //播放声音
            if (!aud.isPlaying)
            {
                aud.Play();
            }
        }
        else
        {
            //停止声音
            aud.Stop();
        }
    }
    //喊叫函数回调 只能有0或1个参数 
    public void PlayShoutAudio()
    {
        //播放喊叫
        AudioSource.PlayClipAtPoint(shoutClip, transform.position);
    }
}
