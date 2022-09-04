using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float flySpeed = 10;

    private RaycastHit hitInfo;

    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //按下左键
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(mousePos);
            //检测鼠标射线碰撞
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject bullet = Instantiate(bulletPrefab, 
                    Camera.main.transform.position,
                    Quaternion.identity);
                //设置初始速度 方向碰撞点跟相机方向
                bullet.GetComponent<Rigidbody>().velocity = flySpeed * (hitInfo.point-Camera.main.transform.position).normalized;
                //延时销毁
                Destroy(bullet, 4f);
            }
        }
    }
}
