using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartsControl : MonoBehaviour
{
    public Star[] Stars;
    private TMP_Text levels;

    private int getStars = 0;//获取星星数量
    // Start is called before the first frame update
    void Start()
    {
        getStars = LevelsSingleton.GetInstance().GetLevelStarFromData();
        levels = transform.Find("ImageHeader/Levels").GetComponent<TMP_Text>();
        levels.text = "Levels"+(LevelsSingleton.GetInstance().CurrentLevel+1);
        Button btn = transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStarsAlpha(int startIdx, int endIdx, float alpha)
    {
        for (int i = startIdx; i <= endIdx; i++)
        {
            Stars[i].SetCurrentAlpha(alpha);
        }

        if (alpha>0.9f)
        {
            getStars = endIdx+1;
        }
        else
        {
            getStars = startIdx;
        }
    }

    public void OnClickButton()
    {
        LevelsSingleton.GetInstance().CurrentStars = getStars;
        LevelsSingleton.GetInstance().SaveLevelData();
        SceneManager.LoadScene("Levels");
    }
    
}
