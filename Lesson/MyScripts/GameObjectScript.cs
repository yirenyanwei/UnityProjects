using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // this的属性
        // transform 组件
        // gameObject 当前对象
        // tag 设置的tag
        // enabled 当前组件是否可用

        #region GameObject静态方法
        //新建游戏对象 创建并添加上
        GameObject obj = new GameObject("xiaoming");
        
        //找到当前游戏对象
        Debug.Log(gameObject);
        
        //找其它游戏对象 
        //通过名称 缺点 1、重名只能找一个 2、消耗性能
        GameObject player = GameObject.Find("Player");
        Debug.Log(player);
        //通过标签 只能找到一个 效率高一点
        GameObject myPlayer = GameObject.FindWithTag("MyPlayer");
        Debug.Log(myPlayer);
        //通过标签 找多个
        GameObject[] myPlayers = GameObject.FindGameObjectsWithTag("MyPlayer");
        Debug.Log(myPlayers);
        #endregion

        #region 成员属性方法
        // gameObject.activeSelf 激活状态
        gameObject.SetActive(true);//激活
        //给当前对象添加组件
        HelloWorld hello = gameObject.AddComponent<HelloWorld>();
        print(hello);
        //获取组件
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();
        print(render);
        render.material.color = new Color(1.0f, 0.0f, 0.0f);

        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
