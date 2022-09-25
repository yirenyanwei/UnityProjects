using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipItem : BagItem,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [Header("父节点")]
    public BoxItem ParentBox;
    // Start is called before the first frame update
    void Start()
    {
        ParentBox = transform.parent.GetComponent<BoxItem>();
    }

    public override void Receive(EquipItem equip)
    {
        //交换
        BoxItem parent = ParentBox;
        BoxItem otherParent = equip.ParentBox;
        BagControl.GetInstance().PutEquip(equip, parent);
        BagControl.GetInstance().PutEquip(this, otherParent);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = transform.root;
        transform.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //转换坐标
        Vector2 temp = Vector2.zero;
        //屏幕坐标转化为本地坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform.parent as RectTransform,
            Input.mousePosition,
            null,
            out temp
        );
        (transform as RectTransform).anchoredPosition = temp;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.GetComponent<Image>().raycastTarget = true;
        
        //判断底下的是格子还是武器
        GameObject enter = eventData.pointerEnter;
        BagItem item = enter.GetComponent<BagItem>();
        if (item != null)
        {
            if (item is EquipItem)
            {
                item.Receive(this);
            }else if (item is BoxItem)
            {
                item.Receive(this);
            }
        }
        else
        {
            //归位
            BagControl.GetInstance().PutEquip(this, ParentBox);
        }
    }
}
