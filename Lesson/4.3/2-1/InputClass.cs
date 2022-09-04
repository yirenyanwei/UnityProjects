using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputClass : MonoBehaviour
{
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按键
        // Input.GetKey() 按住
        // Input.GetKeyDown() 按下
        // Input.GetKeyUp() 抬起
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Down Space");
        }
        //鼠标
        // Input.GetMouseButton() 按住  按下、抬起也一样
        if (Input.GetMouseButtonDown(0))//012 左右中
        {
            print("Down Mouse");
        }
        //鼠标坐标
        // print(Input.mousePosition);
        
        //轴
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        transform.position += new Vector3(hor, 0, ver) * Time.deltaTime * speed;
        
        //虚拟按键
        if (Input.GetButtonDown("Fire1"))
        {
            print("Fire1");
        }
    }
    
    
}
