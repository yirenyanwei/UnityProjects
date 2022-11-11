using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//摄像机跟随
/***
 在正常跟随的基础上做了优化，解决玩家到墙后边遮挡的问题。
 1、摄像机最好的位置G(初始调整的位置)，摄像机最坏的位置B(玩家头顶上)
 2、G和B之间划分几个档，每帧检测摄像机和玩家射线之间有没有障碍物；
 有的话向B档位靠近，没有的话向G靠近，并转动摄像机指向玩家。
 */
public class EthanCameraFollow : MonoBehaviour
{
    [Header("摄像机最好和最差之间的档位")]
    public int gear = 5;
    [Header("移动速度")]
    public float moveSpeed = 3f;
    [Header("转身速度")]
    public float turnSpeed = 2f;
    //跟随的目标
    private Transform followTarget;
    //摄像机指向目标的向量
    private Vector3 dir;
    private RaycastHit hit;
    //玩家身体的偏移
    private float playerBodyOffset = 1f;

    private void Awake()
    {
        followTarget = GameObject.FindWithTag(GameConst.PLAYER).transform;
    }
    //玩家带高度的位置
    Vector3 getTargetPositionWithHeifht()
    {
        return followTarget.position + Vector3.up*playerBodyOffset;
    }
    // Start is called before the first frame update
    void Start()
    {
        //保持相同的向量
        dir = getTargetPositionWithHeifht() - transform.position;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //最好位置
        Vector3 goodPosition = getTargetPositionWithHeifht() - dir;
        //最差位置 头顶位置  添加一个变量来控制相机高度
        Vector3 badPosition = getTargetPositionWithHeifht() + Vector3.up * (dir.magnitude+GameConst.WATCH_OFFSET);
        //中间坐标sss
        Vector3[] watchPositions = new Vector3[gear];
        for (int i = 0; i < gear; i++)
        {
            // watchPositions[i] = goodPosition + (badPosition - goodPosition) / (float)(gear - 1) * i;
            watchPositions[i] = Vector3.Lerp(goodPosition, badPosition, (float)i / (gear - 1));
        }
        //找最合适的点
        Vector3 fitPosition = goodPosition;
        for (int i = 0; i < watchPositions.Length; i++)
        {
            if (CanSeeTarget(watchPositions[i]))
            {
                fitPosition = watchPositions[i];
                break;;
            }
        }
        //移动
        transform.position = Vector3.Lerp(transform.position, fitPosition, Time.deltaTime * moveSpeed);
        //旋转镜头 看向玩家
        Vector3 lookDir = getTargetPositionWithHeifht() - transform.position;
        Quaternion qua = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, qua, Time.deltaTime * turnSpeed);
        //欧拉角修正
        Vector3 eularAngles = transform.eulerAngles;
        eularAngles.y = 0;
        eularAngles.z = 0;
        transform.eulerAngles = eularAngles;
        
    }

    bool CanSeeTarget(Vector3 pos)
    {
        Vector3 currDir = getTargetPositionWithHeifht() - pos;
        if (Physics.Raycast(pos, currDir, out hit))
        {
            //没有障碍物
            if (hit.collider.CompareTag(GameConst.PLAYER))
            {
                return true;
            }
        }
        return false;
    }
}
