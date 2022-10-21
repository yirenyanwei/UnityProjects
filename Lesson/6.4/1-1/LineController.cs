using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //设置定点个数
        line.positionCount = 3;
        //设置定点的位置
        line.SetPosition(0, Vector3.up);
        line.SetPosition(1, Vector3.right);
        line.SetPosition(2, Vector3.down);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
