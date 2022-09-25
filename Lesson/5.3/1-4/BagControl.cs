using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagControl
{
    //单例
    private static BagControl _control;

    private BagControl()
    {
        
    }

    public static BagControl GetInstance()
    {
        if (_control == null)
        {
            _control = new BagControl();
        }

        return _control;
    }
    
    //把装备放到格子下
    public void PutEquip(EquipItem equip, BoxItem box)
    {
        equip.transform.parent = box.transform;
        equip.ParentBox = box;
        (equip.transform as RectTransform).anchoredPosition = Vector2.zero;
    }
}
