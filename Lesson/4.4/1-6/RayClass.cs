using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayClass : MonoBehaviour
{
    private Ray ray;
    //射线检测器
    private RaycastHit hitInfo;
    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(Vector3.up, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        bool isHit = Physics.Raycast(ray, out hitInfo);
        if (Input.GetKey(KeyCode.Space)&&isHit)
        {
            Debug.Log(hitInfo.collider);
            //打印射线
            Debug.DrawRay(ray.origin, ray.direction*10, Color.red);
        }
        
        //鼠标点击射线
        Vector3 pos = Input.mousePosition;
        Ray mouseRay = Camera.main.ScreenPointToRay(pos);
        isHit = Physics.Raycast(mouseRay, out hitInfo);
        if (Input.GetKey(KeyCode.Space)&&isHit)
        {
            Debug.Log(hitInfo.collider);
            //打印线
            Debug.DrawLine(Camera.main.transform.position, hitInfo.point, Color.blue);
        }
    }
}
