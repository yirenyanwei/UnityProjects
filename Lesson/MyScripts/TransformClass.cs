using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformClass : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        #region Transform 控制对象的变换

        Vector3 pos = transform.position;//世界坐标
        print("世界pos:"+pos);
        Vector3 locPos = transform.localPosition;//本地坐标
        print("本地pos:"+locPos);
        //旋转角度 欧拉角
        print("世界angles:"+transform.eulerAngles);
        print("本地angles:"+transform.localEulerAngles);
        //旋转角度 四元数
        print("rotation:"+transform.rotation);
        print("local rotation:"+transform.localPosition);
        //缩放
        print("scale:"+transform.localScale);
        //移动
        transform.Translate(new Vector3(1,1,1));//在原来基础上又移动
        // transform.position += new Vector3(1, 1, 1);//两种移动等价
        //旋转 自转
        transform.Rotate(new Vector3(0,1,0));//在原来基础上旋转
        // transform.localEulerAngles += new Vector3(0, 1, 0);//等价
        //旋转 绕某个对象旋转 绕某个点、某个轴、旋转多少度
        transform.RotateAround(new Vector3(0,0,0), new Vector3(0,1,0), 1);
        //自身向量的上下、左右、前后 变换之后的
        // transform.forward
        // transform.right
        // -transform.up
        print("forward:"+transform.forward);
        //看向某个目标
        transform.LookAt(Target.transform);

        #endregion

        #region Transform 控制对象的层级关系
        //父对象 transform  没有父对象则为Null
        print(transform.parent);
        // transform.SetParent(Target.transform);
        //根对象 没有根对象 返回自己
        print(transform.root);
        //子节点个数
        print(transform.childCount);
        //获取子对象
        print("child:"+transform.GetChild(0));
        //找子对象 只找子对象
        print("findChild:"+transform.Find("Cube"));
        //找子对象的子对象 XPath
        print("findChild-child:"+transform.Find("Cube2/Sphere"));
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(new Vector3(0,1,0));
        // transform.RotateAround(new Vector3(0,0,0), new Vector3(0,1,0), 1);
        // transform.LookAt(Target.transform);
    }
}
