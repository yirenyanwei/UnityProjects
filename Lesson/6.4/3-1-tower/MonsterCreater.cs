using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//怪物波次
[System.Serializable]//序列化特性
public class MonsterWave
{
    [Header("怪物波次时间间隔")]
    public float WaveInterval;
    [Header("怪物时间间隔")]
    public float MonsterInterval;
    [Header("怪物个数")]
    public int MonsetrCount;
    [Header("怪物预设体")]
    public GameObject MonsterPrefab;
    [Header("怪物血量")]
    public float MonsterHP;
    [Header("怪物移动速度")]
    public float MonsterNavSpeed;
}
public class MonsterCreater : MonoBehaviour
{
    [Header("波次信息")]
    public MonsterWave[] Waves;
    
    //计时器
    private float monsterTimer = 0;

    private float waveTimer = 0;
    //怪物个数
    private int counter = 0;
    //波次
    private int waveIdx = 0;
    //起点
    private Transform startTransform;
    //终点
    private Transform endTransform;
    private void Awake()
    {
        startTransform = GameObject.FindWithTag("Start").transform;
        endTransform = GameObject.FindWithTag("End").transform;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (waveIdx>=Waves.Length)
        {
            //所有波次结束
            return;
        }
        waveTimer += Time.deltaTime;

        MonsterWave wave = Waves[waveIdx];
        if (waveTimer>wave.WaveInterval)
        {
            monsterTimer += Time.deltaTime;
            if (counter<wave.MonsetrCount)
            {
                if (monsterTimer>=wave.MonsterInterval)
                {
                    //生成怪物
                    GameObject currMonster = Instantiate(wave.MonsterPrefab, startTransform.position, Quaternion.identity);
                    //初始化monster
                    currMonster.GetComponent<Monster>().InitMonster(wave.MonsterNavSpeed, wave.MonsterHP, endTransform.position);
            
                    counter++;
                    monsterTimer = 0;
                }
            }
            else
            {
                //切换波次
                waveTimer = 0;
                counter = 0;
                monsterTimer = 0;

                waveIdx++;
            }
        }
    }
}
