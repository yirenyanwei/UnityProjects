using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    public float moveSpeed = 3;
    public float turnSpeed = 1;
    public float flySpeed = 10;
    public GameObject bulletPrefab;

    private float ver;
    private float hor;
    private bool isFire = false;
    private Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("Top/Gun/FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        isFire = Input.GetButtonDown("Fire1");
        //前后
        transform.position += transform.forward* ver * moveSpeed * Time.deltaTime;
        //转身 绕y旋转
        transform.eulerAngles += Vector3.up * hor * turnSpeed;
        //开火
        if (isFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward*flySpeed;
            Destroy(bullet, 3);
        }
    }
}
