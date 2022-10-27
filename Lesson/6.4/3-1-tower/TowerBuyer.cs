using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuyer : MonoBehaviour
{
    //单例脚本
    public static TowerBuyer instance;
    [Header("塔预设体数组")]
    public GameObject[] towerPrefabs;
    [Header("初始金钱")]
    public int currentMoney = 300;
    //当前选中的编号 
    private int currIndex = 0;
    //金币ui
    private TMP_Text moneyText;
    //速度
    private Text speedText;
    //射线检测
    private RaycastHit hit;
    private Ray ray;
    private void Awake()
    {
        instance = this;
        moneyText = transform.Find("CoinText").GetComponent<TMP_Text>();
        speedText = transform.Find("Toggle/CheckLabel").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
    }

    public void UpdateMoney(int money = 0)
    {
        currentMoney += money;
        moneyText.text = currentMoney.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.collider.name.Contains("Tower_Base"))
                {
                    return;
                }
                
                Tower tower = towerPrefabs[currIndex].GetComponent<Tower>();
                //判断金币
                if (currentMoney < tower.costMoney)
                {
                    Debug.Log("金币不足");
                    return;
                }
                
                UpdateMoney(-tower.costMoney);
                //底座上 生成炮塔
                GameObject towerObj = Instantiate(towerPrefabs[currIndex], hit.collider.transform);
                towerObj.transform.localPosition = Vector3.up*2.7f;
            }
        }
    }

    public void OnClickTower(int index)
    {
        currIndex = index;
    }

    public void OnClickSpeed(bool change)
    {
        string speed = "X1";
        int timeScale = 1;
        if (change)
        {
            speed = "X2";
            timeScale = 2;
        }

        Time.timeScale = timeScale;
        speedText.text = speed;
    }
}
