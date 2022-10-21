using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerOffMeshNav : MonoBehaviour
{
    [Header("目标")]
    public Transform target;
    //完成跳跃时间
    public float jumpTime = 3;
    //跳跃高度
    public float jumpHeight = 5;
    private NavMeshAgent nav;

    private float progress = 0;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //设置导航目标
        nav.SetDestination(target.position);
        
        //分离路面导航中
        if (nav.isOnOffMeshLink)
        {
           OffMeshLinkData data = nav.currentOffMeshLinkData;
           // data.startPos;//开始点
           // data.endPos;//结束点
           // data.activated; //是否激活
           // data.linkType;//连接类型
           
           //曲线 y = x-x*x  x是时间0~1 y是高度
           progress += Time.deltaTime/jumpTime;
           if (progress<=1)
           {
               transform.position = Vector3.Lerp(data.startPos+Vector3.up*0.5f, data.endPos+Vector3.up*0.5f, progress)+
                                    Vector3.up*(progress-Mathf.Pow(progress, 2))*jumpHeight;
           }
           else
           {
               //完成跳跃，继续后边导航
               nav.CompleteOffMeshLink();
           }

        }
    }
}
