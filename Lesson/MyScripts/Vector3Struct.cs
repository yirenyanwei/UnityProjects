using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Vector3Struct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        //只要是三个浮点数组成的结构，都可以用vector3表示
        #region Member
        Vector3 v3 = new Vector3(1, 1, 1); 
        // v3.x = 0;
        //标准化向量 模长=1
        Vector3 normal = v3.normalized;
        //使当前向量变成单位向量
        normal.Normalize();
        //向量的模
        print(normal.magnitude);
        //模的平方
        print(v3.sqrMagnitude);
        #endregion

        #region Static
        //上下左右 0 1等定义
        // Vector3.left
        // Vector3.up
        // Vector3.forward
        // Vector3.one
        // Vector3.zero
        
        //两个向量距离
        float dis = Vector3.Distance(Vector3.left, Vector3.right);
        print("dis:"+dis);
        //两个向量夹角 正数
        float angle = Vector3.Angle(new Vector3(1,1,0), Vector3.right);
        print("angle:" + angle);
        //叉乘 左手定则 判断左右
        Vector3 cross = Vector3.Cross(Vector3.right, Vector3.up);
        print("cross:"+cross);
        //点乘
        float dot = Vector3.Dot(new Vector3(1, 1, 0), Vector3.right);
        print("dot:"+dot);
        //差值 起点、终点、两点之间值的比例0-1
        Vector3 lerp = Vector3.Lerp(Vector3.zero, Vector3.one * 10, 0.6f);
        print(lerp);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //插值移动  减速运动
        transform.position = Vector3.Lerp(transform.position, Vector3.right * 5, 0.01f);
    }
}
