using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quaternion_Data_Mathf : MonoBehaviour
{
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        #region Quaternion
        //空旋转 复位
        Debug.Log(Quaternion.identity);
        transform.rotation = Quaternion.identity;
        //将向量转换为这个方向代表的四元数  前方看向上边-x轴旋转90度
        Quaternion target = Quaternion.LookRotation(Vector3.up);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //差值向量
        Vector3 v3 = enemy.position - transform.position;
        //将向量转换为这个方向代表的四元数
        Quaternion target = Quaternion.LookRotation(v3);
        // 插值函数 慢慢转头到上方
        transform.rotation = Quaternion.Lerp(transform.rotation, target, 0.01f);
    }
}
