using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshAgent : MonoBehaviour
{
    public Transform Target;

    private NavMeshAgent nav;

    private NavMeshPath path;

    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        line = GetComponent<LineRenderer>();
        
        //预估到目的地，并返回路径
        bool canArrive = nav.CalculatePath(Target.position, path);
        Debug.Log("CanArrive:"+canArrive);
        //拐点
        Vector3[] corners = new Vector3[path.corners.Length + 2];
        corners[0] = transform.position;
        corners[corners.Length - 1] = Target.position;
        float distance = 0;//总的距离
        for (int i = 0; i < path.corners.Length; i++)
        {
            corners[i + 1] = path.corners[i];
            distance += Vector3.Distance(corners[i], corners[i + 1]);
            //画路径
            Debug.DrawLine(corners[i], corners[i + 1], Color.black);
        }
        Debug.Log("distance:"+distance);
        //lineRender画线
        line.positionCount = corners.Length;
        for (int i = 0; i < corners.Length; i++)
        {
            Debug.Log(corners[i]);
            line.SetPosition(i, corners[i]);
        }
        
        //导航的层剔除 所选层2的次幂的和
        Debug.Log("areaMask:"+nav.areaMask);
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(Target.position);
        
        //导航的瞬时速度
        // Debug.Log("velocity:"+nav.velocity);
        Debug.DrawRay(transform.position, nav.velocity, Color.blue);
        //导航的期望速度   一直指向前方
        // Debug.Log("desiredVelocity:"+nav.desiredVelocity);
        Debug.DrawRay(transform.position+Vector3.up*0.5f, nav.desiredVelocity, Color.yellow);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //暂停 开始
            nav.isStopped = !nav.isStopped;
        }
        
        //判断导航结束
        if (nav.remainingDistance-nav.stoppingDistance<=0.05)
        {
            Debug.Log("导航结束");
        }
    }
}
