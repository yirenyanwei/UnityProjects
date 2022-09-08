using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public float interval = 1;

    private float timer = 0;
    private TMP_Text myText;
    private string originText;
    private string startTag = "<color=red>";
    private string endTag = "</color>";

    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<TMP_Text>();
        
        originText = myText.text;
    } 

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=interval)
        {
            counter++;
            while (counter<=originText.Length && originText[counter-1]==' ')
            {
                //跳过空格
                counter++;
            } 
            if (counter<=originText.Length)
            {
                myText.text = startTag + originText.Insert(counter, endTag);
            }
            timer = 0;
        }
    }
}
