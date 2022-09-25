using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{
    [Header("带解锁的关卡")]
    public int nextLevel = 2;
    [Header("锁定关卡的颜色")]
    public Color lockLevelColor = Color.white;
    [Header("选中")]
    private Transform selectImg;
    // Start is called before the first frame update
    void Start()
    {
        selectImg = GameObject.FindWithTag("Select").transform;
        ShowLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //展示等级
    public void ShowLevels()
    {
        nextLevel = LevelsSingleton.GetInstance().LevelsStars.Count + 2;
        OnClickLevelButton(LevelsSingleton.GetInstance().LevelsStars.Count);
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            TMP_Text levelText = child.Find("LevelText").GetComponent<TMP_Text>();
            levelText.text = (i + 1).ToString();
            Transform lockImg = child.Find("Lock");
            bool isUnLock = i < nextLevel - 1;
            lockImg.gameObject.SetActive(!isUnLock);
            child.GetComponent<Button>().interactable = isUnLock;
            if (!isUnLock)
            {
                levelText.color = lockLevelColor;
            }
            //星星显示
            Transform StarNode = child.Find("StarNode");
            if (isUnLock)
            {
                StarNode.gameObject.SetActive(true);
                int stars = LevelsSingleton.GetInstance().GetLevelStarFromData(i);
                Debug.Log(i+"--"+stars);
                for (int j = 0; j < StarNode.childCount; j++)
                {
                    StarNode.GetChild(j).gameObject.SetActive(stars>=j+1);
                }
            }
        }
    }
    //点击按钮 level从0开始
    public void OnClickLevelButton(int level)
    {
        Transform levelTf = transform.GetChild(level);
        selectImg.SetParent(levelTf);
        (selectImg as RectTransform).anchoredPosition = Vector3.zero;
        //调整z轴 设置在兄弟对象中的顺序
        selectImg.SetSiblingIndex(0);
        //存储关卡
        LevelsSingleton.GetInstance().CurrentLevel = level;
    }
    //进入关卡
    public void OnClickEnterGame()
    {
        SceneManager.LoadScene("Starts");
    }
}
