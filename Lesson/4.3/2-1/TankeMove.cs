using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankeMove : MonoBehaviour
{
    public GameObject Bullet;//炮弹
    [Header("移动速度")]
    public float MoveSpeed = 1;
    [Header("转身速度")]
    public float TurnSpeed = 1;

    
    private float hor;

    private float ver;

    private bool fire;

    private Transform firePoint;//炮弹位置
    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePosition");
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        fire = Input.GetButtonDown("Fire1");

        //前后移动
        transform.position += transform.forward * ver * Time.deltaTime * MoveSpeed;
        //转身
        transform.eulerAngles += Vector3.up * hor * TurnSpeed;

        if (fire)
        {
            GameObject blt = Instantiate(Bullet, firePoint.position, Quaternion.identity);
            blt.GetComponent<Bullet>().MoveDir = transform.forward;
            //3s后销毁
            Destroy(blt, 3f);
        }
    }
}
