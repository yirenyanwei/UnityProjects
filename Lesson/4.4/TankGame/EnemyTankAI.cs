using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//敌人AI
public class EnemyTankAI : MonoBehaviour
{
    public float moveSpeed = 3;
    public float turnSpeed = 1;
    [Header("发射炮弹时间间隔")]
    public float fireInterval = 3;
    public GameObject bulletPrefab;
    public float flySpeed = 20;
    
    private Transform playerTank;
    private Transform firePoint;
    private float distance;
    private RaycastHit hitInfo;

    private float timer;
    //巡逻随机的角度
    private Quaternion randomRotation;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("Top/Gun/FirePoint");
        //玩家坦克
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(transform.position, playerTank.position);
        if (distance<10)
        {
            Fire();
        }else if (distance < 20)
        {
            Move();
        }
        else
        {
            Patrol();
        }
    }
    //转向玩家
    private void RotateToPlayer()
    {
        //当前坦克指向玩家的向量
        Vector3 dir = playerTank.position - transform.position;
        RotateTo(dir);
    }
    private void RotateTo(Vector3 dir)
    {
        //把目标点转成四元数
        Quaternion qua = Quaternion.LookRotation(dir);
        RotateTo(qua);
    }

    private void RotateTo(Quaternion qua)
    {
        //插值转过去
        transform.rotation = Quaternion.Lerp(transform.rotation, qua, turnSpeed*Time.deltaTime);
    }
    //判断前方有没有友方
    private bool CheckForwardFriends(float dis)
    {
        //射线检测
        if (Physics.Raycast(firePoint.position, 
                transform.forward, 
                out hitInfo, dis))
        {
            //找到碰撞体的根对象
            Transform other = hitInfo.collider.gameObject.transform.root;
            if (other.tag == "Enemy")
            {
                return true;
            }
        }

        return false;
    }
    //攻击
    private void Fire()
    {
        RotateToPlayer();
        if (CheckForwardFriends(10))
        {
            //前方是友军
            return;
        }
        //发射
        if (timer>=fireInterval)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward*flySpeed;
            Destroy(bullet, 3);
            timer = 0;
        }
    }
    //向玩家移动
    private void Move()
    {
        RotateToPlayer();
        //移动
        if (!CheckForwardFriends(2))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
    //巡逻
    private void Patrol()
    {
        //随机的转身移动
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (timer >= fireInterval)
        {
            //随机角度
            float y = Random.Range(0f, 360f);
            randomRotation = Quaternion.Euler(new Vector3(0, y, 0));
            timer = 0;
        }
        RotateTo(randomRotation);
    }
}
