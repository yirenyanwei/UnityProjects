using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    EquipTypeNone,
    EquipType1,
    EquipType2,
    EquipType3,
    EquipType4,
}
//基类
public abstract class BagItem: MonoBehaviour
{
    //类型
    public EquipType MyEquipType = EquipType.EquipTypeNone;
    //接收
    abstract public void Receive(EquipItem equip);
}
