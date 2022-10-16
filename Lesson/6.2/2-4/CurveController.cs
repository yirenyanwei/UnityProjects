using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveController : MonoBehaviour
{
    private Animator ani;

    private BoxCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //正在执行死亡动画
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Dying"))
        {
            SetBoxHeight();
        }
    }

    public void SetBoxHeight()
    {
        float height = ani.GetFloat("BoxHeight");
        collider.size = new Vector3(collider.size.x, height, collider.size.z);
        
        float center = ani.GetFloat("BoxCenter");
        collider.center = new Vector3(collider.center.x, center, collider.center.z);
    }
}
