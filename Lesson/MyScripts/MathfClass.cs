using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //绝对值
        print("abs:"+Mathf.Abs(-1));
        //差值
        print("lerp:"+Mathf.Lerp(0,10,0.5f));
        //限制值 在某个区间内
        print("clamp:" + Mathf.Clamp(2.5f, 5,8));
        //限制到0-1
        print("clamp01"+Mathf.Clamp01(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
