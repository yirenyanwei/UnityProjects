using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCD : MonoBehaviour
{
    [Header("技能cd")]
    [Range(0,100)]
    public float cd = 3;

    private Image maskImage;

    private float timer = 0;

    private bool beganCD = false;

    private TMP_Text cdText;
    // Start is called before the first frame update
    void Start()
    {
        maskImage = GetComponent<Image>();
        cdText = transform.Find("TextTime").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!beganCD)
        {
            beganCD = true;
            maskImage.fillAmount = 1;
            timer = 0;
        }

        if (beganCD)
        {
            timer += Time.deltaTime;
            maskImage.fillAmount = 1 - timer / cd;
            cdText.text = (cd - timer).ToString("0.00");
            if (timer>cd)
            {
                maskImage.fillAmount = 0;
                beganCD = false;
                cdText.text = "";
            }
        }
    }
}
