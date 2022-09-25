using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItem : BagItem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Receive(EquipItem equip)
    {
        BagControl.GetInstance().PutEquip(equip, this);
    }
}
