using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnController : MonoBehaviour
{
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        //给按钮绑定点击事件 只能添加空参数事件
        btn.onClick.AddListener(OnButtonClick);
        //移除监听
        // btn.onClick.RemoveListener(OnButtonClick);
        //移除所有监听
        // btn.onClick.RemoveAllListeners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Click");
    }
}
