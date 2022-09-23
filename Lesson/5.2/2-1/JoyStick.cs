using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,
    IBeginDragHandler,
    IEndDragHandler,
    IDragHandler
{
    public float MoveRadious = 100;//移动半径

    public float Speed = 1;//玩家移动速度

    private Vector3 originPos;//初始距离

    private float moveDistance;//距原点的距离

    private Vector3 dir;

    private CharacterController player;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        dir = Input.mousePosition - originPos;
        //鼠标与远点位置
        moveDistance = dir.magnitude;
        dir.Normalize();
        if (moveDistance<=MoveRadious)
        {
            transform.position = Input.mousePosition;
        }
        else
        {
            //求圆与线的交点
            Vector3 point = dir * MoveRadious + originPos;
            transform.position = point;
        }
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //回到原始位置
        transform.position = originPos;
        //归零  
        dir = Vector3.zero;
    }

    public void PlayerControl()
    {
        // player.position +=  new Vector3(dir.x, 0, dir.y)* Speed*Time.deltaTime;
        //一般使用SimpleMove
        player.SimpleMove(new Vector3(dir.x, 0, dir.y)* Speed*Time.deltaTime);
    }
}
