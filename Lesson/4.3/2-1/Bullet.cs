using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //子弹飞行方向
    [HideInInspector]
    public Vector3 MoveDir;
    //子弹飞行速度
    public float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += MoveDir * moveSpeed * Time.deltaTime;
    }
}
