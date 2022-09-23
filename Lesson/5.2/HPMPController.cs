using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPMPController : MonoBehaviour
{
    public float Speed = 3;//增长速度
    public float MAXHPValue = 1000;
    public float MAXMPValue = 800;
    
    private RectTransform HPRect;

    private RectTransform MPRect;

    private TMP_Text HPText;

    private TMP_Text MPText;

    private float hor, ver;

    private float MAXHP = 220;

    private float MAXMP = 220;

    private float NowHP = 220;

    private float NowMP = 220;
    // Start is called before the first frame update
    void Start()
    {
        HPRect = transform.Find("HPImage/HPProgress") as RectTransform;
        MPRect = transform.Find("MPImage/MPProgress") as RectTransform;

        HPText = transform.Find("HPImage/HPText").GetComponent<TMP_Text>();
        MPText = transform.Find("MPImage/MPText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        
        //hp
        NowHP += Time.deltaTime * Speed*hor;
        NowHP = Mathf.Clamp(NowHP, 0, MAXHP);
        HPRect.sizeDelta = new Vector2(NowHP, HPRect.sizeDelta.y);
        //mp
        NowMP += Time.deltaTime * Speed * ver;
        NowMP = Mathf.Clamp(NowMP, 0, MAXMP);
        MPRect.sizeDelta = new Vector2(NowMP, MPRect.sizeDelta.y);

        HPText.text = (NowHP / MAXHP * MAXHPValue).ToString("0.0");
        MPText.text = (NowMP / MAXMP * MAXMPValue).ToString("0.0");
    }
}
