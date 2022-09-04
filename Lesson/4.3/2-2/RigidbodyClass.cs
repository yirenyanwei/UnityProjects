using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyClass : MonoBehaviour
{
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //添加瞬时速度
            rig.velocity = Vector3.up*5 ;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            //施加瞬间的力
            rig.AddForce(Vector3.right*100);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //添加爆炸力
            rig.AddExplosionForce(500, transform.position+Vector3.left, 3);
        }
    }
}
