using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//生成坦克
public class EnemyTankManager : MonoBehaviour
{
    public GameObject enemyTankPrefab;
    [Header("生成的时间间隔")]
    public float interval = 3f;
    [Header("生成的最大数量")]
    [Range(0,100)]
    public int maxNum = 50;

    //计时器
    private float timer=0;
    //计数器
    private int counter=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=interval)
        {
            CreateTank();
            timer = 0;
        }
    }
    //创建坦克
    private void CreateTank()
    {
        if (counter>maxNum)
        {
            return;
        }
        //位置(-40~40)
        Vector3 pos;
        do
        {
            float x = Random.Range(-40f, 40f);
            float z = Random.Range(-40f, 40f);
            pos = new Vector3(x, 0, z);
        } while (!CanUsePosition(pos));
        //角度
        float y = Random.Range(0f, 360f);
        Quaternion qua = Quaternion.Euler(new Vector3(0, y, 0));
        GameObject enemy = Instantiate(enemyTankPrefab, 
            pos, 
            qua);
        counter++;

    }
    //这个位置是否可用
    private bool CanUsePosition(Vector3 pos)
    {
        //位置 半径 检测的层（除去第8层地面层都检测）
        //是否检测到碰撞体
        return !Physics.CheckSphere(pos, 2f, ~(1 << 8));
        //拓展，除了第8、9层都检测
        // ~(1<<8 | 1<<9)
    }
}
