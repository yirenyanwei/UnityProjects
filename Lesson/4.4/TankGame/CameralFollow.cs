using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//摄像机跟随
public class CameralFollow : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        //摄像机和玩家保持一个固定的方向向量
        dir = targetPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = targetPlayer.position - dir;
    }
}
