using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //按钮点击，参数0或1个
    public void OnButtonClick(string msg)
    {
        Debug.Log("Click Button+"+msg);
    }
}
